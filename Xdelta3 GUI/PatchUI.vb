Imports System
Imports System.IO
' And System.Security.Cryptography for Hashes : MD5, SHA1, SHA256, ...
Imports System.Security
Imports System.Security.Cryptography

Public Class PatchUI
    Dim InputSize As Long
    Dim WinSize As Long
    Dim varProgress As Long
    Dim CurrentBlock As Long
    Dim SelectDiff As New OpenFileDialog
    Dim SelectSource As New OpenFileDialog
    Dim SelectOutput As New SaveFileDialog
    Dim SelectScript As New OpenFileDialog
    Dim varSeconds As Long
    Dim varMemory As Long
    Dim TotalTask As Integer
    Dim CurrentTask As Integer
    Dim strLineStream As Object
    Private WithEvents proc_ApplyDelta As Process
    Private WithEvents proc_ReadHdr As Process
    Private Delegate Sub AppendOutputTextDelegate(ByVal text As String)

    Private Sub PatchUI_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.btnStop.Enabled = False
    End Sub

    Private Sub OutputTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles OutputTextBox.TextChanged
        If txtTextOutput.Text.StartsWith("xdelta3:") Or txtTextOutput.Text.StartsWith("VCDIFF") Then
            If txtTextOutput.Text.StartsWith("xdelta3: source ") Then
                InputSize = txtTextOutput.Text.Substring(txtTextOutput.Text.IndexOf("[") + 1, txtTextOutput.Text.IndexOf("]") - txtTextOutput.Text.IndexOf("[") - 1)
                Label1.Text = "Source File Size: " & InputSize & " Byte"
            End If

            Dim WinSizePhase As String = "VCDIFF target window length:"
            If txtTextOutput.Text.StartsWith(WinSizePhase) Then
                InputSize = 0
                WinSize = 0
                varProgress = 0
                CurrentBlock = 0
                WinSize = txtTextOutput.Text.Substring(WinSizePhase.Length).Trim
                Label1.Text = "Source File Size: Unknown"
                Label2.Text = "Input Window Size: " & WinSize / 1024 & " KB"
            End If

            Dim CurrentBlockPhase As String = "xdelta3: "
            If txtTextOutput.Text.StartsWith("xdelta3: finished") Then
                CurrentBlock = varProgress
                btnStart.Enabled = True
                btnStop.Enabled = False
            Else
                If txtTextOutput.Text.EndsWith("ms") Or txtTextOutput.Text.EndsWith("sec") Then
                    CurrentBlock = txtTextOutput.Text.Substring(txtTextOutput.Text.IndexOf(CurrentBlockPhase) + CurrentBlockPhase.Length, txtTextOutput.Text.IndexOf(": in ") - CurrentBlockPhase.Length)
                End If
            End If
            If InputSize > 0 And WinSize > 0 Then
                varProgress = (InputSize / WinSize)
                'ProgressBar1.CreateGraphics().DrawString(Math.Round(CurrentBlock / varProgress * 100, 0) & "%", New Font("Arial", 8.25, FontStyle.Regular), Brushes.Black, New PointF(ProgressBar1.Width / 2 - 10, ProgressBar1.Height / 2 - 7))
                ProgressBar1.Value = CurrentBlock / varProgress * 10000
                'ProgressBar1.CreateGraphics().DrawString(Math.Round(CurrentBlock / varProgress * 100, 0) & "%", New Font("Arial", 8.25, FontStyle.Regular), Brushes.Black, New PointF(ProgressBar1.Width / 2 - 10, ProgressBar1.Height / 2 - 7))

                Label3.Text = "Progress: " & Math.Round(CurrentBlock / varProgress * 100, 0) & "%"
            Else
                'ProgressBar1.CreateGraphics().DrawString("0%", New Font("Arial", 8.25, FontStyle.Regular), Brushes.Black, New PointF(ProgressBar1.Width / 2 - 10, ProgressBar1.Height / 2 - 7))
                Label3.Text = "Progress: Unknown"
                ProgressBar1.Value = 0
            End If
        End If
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            proc_ApplyDelta.Kill()
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
        Try
            proc_ApplyDelta.Dispose()
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
        Try
            proc_ApplyDelta.Close()
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub AppendOutputText(ByVal text As String)
        If OutputTextBox.InvokeRequired Then
            Dim myDelegate As New AppendOutputTextDelegate(AddressOf AppendOutputText)
            Me.Invoke(myDelegate, text)
        Else
            OutputTextBox.AppendText(vbCrLf & text)
            txtTextOutput.Text = text
        End If
    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        btnStop.Enabled = False
        Try
            If proc_ApplyDelta.Responding Then
                proc_ApplyDelta.Kill()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btnSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSource.Click
        With SelectSource
            .Title = "Select source file"
        End With
        If DialogResult.OK = SelectSource.ShowDialog Then
            txtSource.Text = SelectSource.FileName
        End If
    End Sub

    Private Sub btnSelectDiff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectDiff.Click
        With SelectDiff
            .Title = "Select DIFF file"
        End With
        If DialogResult.OK = SelectDiff.ShowDialog Then
            txtDiff.Text = SelectDiff.FileName
        End If
        ReadHeader(SelectOutput.FileName)
    End Sub

    Private Sub btnOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOut.Click
        With SelectOutput
            .Title = "Select output file"
            If Not String.IsNullOrEmpty(SelectDiff.FileName) Or Not String.IsNullOrEmpty(SelectSource.FileName) Then
                .InitialDirectory = Path.GetDirectoryName(SelectSource.FileName)
                .FileName = Path.GetFileNameWithoutExtension(SelectDiff.FileName)
                .Filter = "Source File Type|*" & Path.GetExtension(SelectSource.FileName) & "|All files (*.*)|*.*"
                .FilterIndex = 1
            End If
        End With
        If DialogResult.OK = SelectOutput.ShowDialog Then
            txtOutput.Text = SelectOutput.FileName
        Else
            SelectOutput.FileName = Nothing
        End If
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        If String.IsNullOrEmpty(SelectSource.FileName) Or String.IsNullOrEmpty(SelectDiff.FileName) Then
            AppendOutputText("Select required files first!")
            Exit Sub
        End If
        If String.IsNullOrEmpty(SelectOutput.FileName) Then
            AppendOutputText("Select required files first!")
            btnOut_Click(sender, e)
        End If
        If String.IsNullOrEmpty(SelectOutput.FileName) Then Exit Sub
        btnStart.Enabled = False
        OutputTextBox.Clear()
        CheckExitTimer.Start()
        PatchLoop()
    End Sub

    Private Sub PatchLoop()
        ReadHeader(SelectOutput.FileName)
    End Sub

    Private Sub ReadHeader(ByVal DiffFile As String)
        proc_ReadHdr = New Process
        With proc_ReadHdr
            With .StartInfo
                .FileName = "xdelta64.exe"
                .Arguments = "printhdr " & Chr(34) & DiffFile & Chr(34)
                '.Arguments = "printhdr " & Chr(34) & SelectDiff.FileName & Chr(34)
                .UseShellExecute = False
                .CreateNoWindow = True
                .RedirectStandardInput = True
                .RedirectStandardOutput = True
                .RedirectStandardError = True
            End With
            .Start()
            .BeginErrorReadLine()
            .BeginOutputReadLine()
            .WaitForExit(1000)
        End With
    End Sub

    Private Sub ApplyDelta(ByVal varSource As String, ByVal varDiff As String, ByVal varOutput As String)
        proc_ApplyDelta = New Process
        With proc_ApplyDelta
            With .StartInfo
                .FileName = "xdelta64.exe"
                .Arguments = "-B" & varMemory & " -vfds " & Chr(34) & varSource & Chr(34) & " " & Chr(34) & varDiff & Chr(34) & " " & Chr(34) & varOutput & Chr(34)
                '.Arguments = "-vfds " & Chr(34) & varSource & Chr(34) & " " & Chr(34) & varDiff & Chr(34) & " " & Chr(34) & varOutput & Chr(34)
                .UseShellExecute = False
                .CreateNoWindow = True
                .RedirectStandardInput = True
                .RedirectStandardOutput = True
                .RedirectStandardError = True
            End With
            .Start()
            .BeginErrorReadLine()
            .BeginOutputReadLine()
        End With
    End Sub

    Private Sub ReadHdr_Exited(ByVal sender As Object, ByVal e As System.EventArgs) Handles proc_ReadHdr.Exited
        btnStart.Enabled = False
        btnStop.Enabled = True
        'AppendOutputText("ReadHdr Exited")
        'ApplyDelta(SelectSource.FileName, SelectDiff.FileName, SelectOutput.FileName)
        ApplyDelta(strLineStream(CurrentTask).split(",")(0).trim(), strLineStream(CurrentTask).split(",")(1).trim(), strLineStream(CurrentTask).split(",")(2).trim())
    End Sub

    Private Sub ApplyDelta_Exited(ByVal sender As Object, ByVal e As System.EventArgs) Handles proc_ApplyDelta.Exited
        'AppendOutputText("ApplyDelta Exited")
        btnStart.Enabled = True
        btnStop.Enabled = False
        varSeconds = Nothing
        CheckExitTimer.Stop()
        CurrentTask += 1
    End Sub

    Private Sub proc_ReadHdr_ErrorDataReceived(ByVal sender As Object, ByVal e As System.Diagnostics.DataReceivedEventArgs) Handles proc_ReadHdr.ErrorDataReceived
        AppendOutputText(e.Data)
    End Sub

    Private Sub proc_ReadHdr_OutputDataReceived(ByVal sender As Object, ByVal e As System.Diagnostics.DataReceivedEventArgs) Handles proc_ReadHdr.OutputDataReceived
        AppendOutputText(e.Data)
    End Sub

    Private Sub proc_ApplyDelta_ErrorDataReceived(ByVal sender As Object, ByVal e As System.Diagnostics.DataReceivedEventArgs) Handles proc_ApplyDelta.ErrorDataReceived
        AppendOutputText(e.Data)
    End Sub

    Private Sub proc_ApplyDelta_OutputDataReceived(ByVal sender As Object, ByVal e As System.Diagnostics.DataReceivedEventArgs) Handles proc_ApplyDelta.OutputDataReceived
        AppendOutputText(e.Data)
    End Sub

    Private Sub CheckExitTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckExitTimer.Tick
        varSeconds += 1
        lblTime.Text = varSeconds
        Try
            If proc_ReadHdr.HasExited And proc_ApplyDelta.HasExited Then
                CheckExitTimer.Stop()
                PharsePatchScript(SelectScript.FileName)
            End If
        Catch ex As Exception
            AppendOutputText(ex.ToString)
        End Try
    End Sub

    Private Sub CheckExit()
        Try
            If proc_ReadHdr.HasExited And proc_ApplyDelta.HasExited Then
                'AppendOutputText("Both Exited: " & DateTime.Now)
                'PharsePatchScript(SelectScript.FileName)
            End If
        Catch ex As Exception
            AppendOutputText(ex.ToString)
        End Try
    End Sub

    Private Sub mem_default_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mem_default.CheckedChanged
        varMemory = 67108864
    End Sub

    Private Sub mem_1GB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mem_1GB.CheckedChanged
        varMemory = 1073741824
    End Sub

    Private Sub mem_2GB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mem_2GB.CheckedChanged
        varMemory = 2147483648
    End Sub

    Private Sub btnLoadScript_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadScript.Click
        With SelectScript
            .Title = "Load script file"
        End With
        If DialogResult.OK = SelectScript.ShowDialog Then
            btnLoadScript.Enabled = False
            PharsePatchScript(SelectScript.FileName)
        End If
    End Sub

    Private Sub PharsePatchScript(ByVal PatchScript As String)
        Dim objTaskFile As New StreamReader(PatchScript)
        strLineStream = objTaskFile.ReadToEnd.Split(Chr(13))
        TotalTask = UBound(strLineStream)
        'MsgBox(TotalTask)
        If CurrentTask = TotalTask Then
            AppendOutputText("All tasks completed.")
            CurrentTask = 0
            btnLoadScript.Enabled = True
            objTaskFile.Close()
        Else
            If Not CurrentTask > TotalTask Then
                If strLineStream(CurrentTask).indexof(",") > 0 Then
                    'MsgBox("Source: " + strLineStream(CurrentTask).split(",")(0).trim() + Chr(13) + "Source: " + strLineStream(CurrentTask).split(",")(1).trim() + Chr(13) + "Source: " + strLineStream(CurrentTask).split(",")(2).trim())
                    lblSource.Text = strLineStream(CurrentTask).split(",")(0).trim()
                    lblPatch.Text = strLineStream(CurrentTask).split(",")(1).trim()
                    lblOutput.Text = strLineStream(CurrentTask).split(",")(2).trim()
                    CheckExitTimer.Start()
                    ReadHeader(strLineStream(CurrentTask).split(",")(1).trim())
                End If
            End If
        End If
    End Sub

    Private Sub btnHashCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHashCheck.Click

    End Sub

End Class
