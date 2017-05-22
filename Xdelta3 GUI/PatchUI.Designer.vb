<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PatchUI
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.txtTextOutput = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.OutputTextBox = New System.Windows.Forms.TextBox
        Me.btnStop = New System.Windows.Forms.Button
        Me.btnStart = New System.Windows.Forms.Button
        Me.btnSelectDiff = New System.Windows.Forms.Button
        Me.txtDiff = New System.Windows.Forms.TextBox
        Me.txtSource = New System.Windows.Forms.TextBox
        Me.txtOutput = New System.Windows.Forms.TextBox
        Me.btnSource = New System.Windows.Forms.Button
        Me.btnOut = New System.Windows.Forms.Button
        Me.CheckExitTimer = New System.Windows.Forms.Timer(Me.components)
        Me.lblTime = New System.Windows.Forms.Label
        Me.mem_default = New System.Windows.Forms.RadioButton
        Me.mem_1GB = New System.Windows.Forms.RadioButton
        Me.mem_2GB = New System.Windows.Forms.RadioButton
        Me.gp_mem = New System.Windows.Forms.GroupBox
        Me.btnLoadScript = New System.Windows.Forms.Button
        Me.lblSource = New System.Windows.Forms.Label
        Me.lblPatch = New System.Windows.Forms.Label
        Me.lblOutput = New System.Windows.Forms.Label
        Me.btnHashCheck = New System.Windows.Forms.Button
        Me.gp_mem.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtTextOutput
        '
        Me.txtTextOutput.Location = New System.Drawing.Point(12, 624)
        Me.txtTextOutput.Name = "txtTextOutput"
        Me.txtTextOutput.ReadOnly = True
        Me.txtTextOutput.Size = New System.Drawing.Size(699, 20)
        Me.txtTextOutput.TabIndex = 0
        Me.txtTextOutput.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Source File Size:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Input Window Size: "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(9, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Progress:"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 97)
        Me.ProgressBar1.MarqueeAnimationSpeed = 10
        Me.ProgressBar1.Maximum = 10000
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(590, 23)
        Me.ProgressBar1.Step = 1
        Me.ProgressBar1.TabIndex = 5
        '
        'OutputTextBox
        '
        Me.OutputTextBox.Location = New System.Drawing.Point(12, 126)
        Me.OutputTextBox.Multiline = True
        Me.OutputTextBox.Name = "OutputTextBox"
        Me.OutputTextBox.ReadOnly = True
        Me.OutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.OutputTextBox.Size = New System.Drawing.Size(699, 492)
        Me.OutputTextBox.TabIndex = 6
        Me.OutputTextBox.TabStop = False
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(143, 65)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(125, 23)
        Me.btnStop.TabIndex = 4
        Me.btnStop.Text = "STOP"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(196, 657)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(125, 23)
        Me.btnStart.TabIndex = 3
        Me.btnStart.Text = "START"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnSelectDiff
        '
        Me.btnSelectDiff.Location = New System.Drawing.Point(586, 684)
        Me.btnSelectDiff.Name = "btnSelectDiff"
        Me.btnSelectDiff.Size = New System.Drawing.Size(125, 23)
        Me.btnSelectDiff.TabIndex = 1
        Me.btnSelectDiff.Text = "Open DIFF File..."
        Me.btnSelectDiff.UseVisualStyleBackColor = True
        '
        'txtDiff
        '
        Me.txtDiff.Location = New System.Drawing.Point(327, 686)
        Me.txtDiff.Name = "txtDiff"
        Me.txtDiff.ReadOnly = True
        Me.txtDiff.Size = New System.Drawing.Size(253, 20)
        Me.txtDiff.TabIndex = 1
        Me.txtDiff.TabStop = False
        '
        'txtSource
        '
        Me.txtSource.Location = New System.Drawing.Point(327, 657)
        Me.txtSource.Name = "txtSource"
        Me.txtSource.ReadOnly = True
        Me.txtSource.Size = New System.Drawing.Size(253, 20)
        Me.txtSource.TabIndex = 0
        Me.txtSource.TabStop = False
        '
        'txtOutput
        '
        Me.txtOutput.Location = New System.Drawing.Point(327, 714)
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.ReadOnly = True
        Me.txtOutput.Size = New System.Drawing.Size(253, 20)
        Me.txtOutput.TabIndex = 2
        Me.txtOutput.TabStop = False
        '
        'btnSource
        '
        Me.btnSource.Location = New System.Drawing.Point(586, 655)
        Me.btnSource.Name = "btnSource"
        Me.btnSource.Size = New System.Drawing.Size(125, 23)
        Me.btnSource.TabIndex = 0
        Me.btnSource.Text = "Open Source File..."
        Me.btnSource.UseVisualStyleBackColor = True
        '
        'btnOut
        '
        Me.btnOut.Location = New System.Drawing.Point(586, 712)
        Me.btnOut.Name = "btnOut"
        Me.btnOut.Size = New System.Drawing.Size(125, 23)
        Me.btnOut.TabIndex = 2
        Me.btnOut.Text = "Select Output"
        Me.btnOut.UseVisualStyleBackColor = True
        '
        'CheckExitTimer
        '
        Me.CheckExitTimer.Interval = 1000
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Location = New System.Drawing.Point(264, 45)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(33, 13)
        Me.lblTime.TabIndex = 7
        Me.lblTime.Text = "Timer"
        '
        'mem_default
        '
        Me.mem_default.AutoSize = True
        Me.mem_default.Location = New System.Drawing.Point(6, 19)
        Me.mem_default.Name = "mem_default"
        Me.mem_default.Size = New System.Drawing.Size(53, 17)
        Me.mem_default.TabIndex = 8
        Me.mem_default.Text = "64MB"
        Me.mem_default.UseVisualStyleBackColor = True
        '
        'mem_1GB
        '
        Me.mem_1GB.AutoSize = True
        Me.mem_1GB.Location = New System.Drawing.Point(6, 42)
        Me.mem_1GB.Name = "mem_1GB"
        Me.mem_1GB.Size = New System.Drawing.Size(46, 17)
        Me.mem_1GB.TabIndex = 9
        Me.mem_1GB.Text = "1GB"
        Me.mem_1GB.UseVisualStyleBackColor = True
        '
        'mem_2GB
        '
        Me.mem_2GB.AutoSize = True
        Me.mem_2GB.Checked = True
        Me.mem_2GB.Location = New System.Drawing.Point(6, 65)
        Me.mem_2GB.Name = "mem_2GB"
        Me.mem_2GB.Size = New System.Drawing.Size(46, 17)
        Me.mem_2GB.TabIndex = 10
        Me.mem_2GB.TabStop = True
        Me.mem_2GB.Text = "2GB"
        Me.mem_2GB.UseVisualStyleBackColor = True
        '
        'gp_mem
        '
        Me.gp_mem.Controls.Add(Me.mem_default)
        Me.gp_mem.Controls.Add(Me.mem_1GB)
        Me.gp_mem.Controls.Add(Me.mem_2GB)
        Me.gp_mem.Location = New System.Drawing.Point(608, 6)
        Me.gp_mem.Name = "gp_mem"
        Me.gp_mem.Size = New System.Drawing.Size(103, 114)
        Me.gp_mem.TabIndex = 12
        Me.gp_mem.TabStop = False
        Me.gp_mem.Text = "Memory Usage"
        '
        'btnLoadScript
        '
        Me.btnLoadScript.Location = New System.Drawing.Point(12, 65)
        Me.btnLoadScript.Name = "btnLoadScript"
        Me.btnLoadScript.Size = New System.Drawing.Size(125, 23)
        Me.btnLoadScript.TabIndex = 12
        Me.btnLoadScript.Text = "Load Script"
        Me.btnLoadScript.UseVisualStyleBackColor = True
        '
        'lblSource
        '
        Me.lblSource.AutoSize = True
        Me.lblSource.Location = New System.Drawing.Point(264, 6)
        Me.lblSource.Name = "lblSource"
        Me.lblSource.Size = New System.Drawing.Size(47, 13)
        Me.lblSource.TabIndex = 13
        Me.lblSource.Text = "Source: "
        '
        'lblPatch
        '
        Me.lblPatch.AutoSize = True
        Me.lblPatch.Location = New System.Drawing.Point(264, 19)
        Me.lblPatch.Name = "lblPatch"
        Me.lblPatch.Size = New System.Drawing.Size(41, 13)
        Me.lblPatch.TabIndex = 14
        Me.lblPatch.Text = "Patch: "
        '
        'lblOutput
        '
        Me.lblOutput.AutoSize = True
        Me.lblOutput.Location = New System.Drawing.Point(264, 32)
        Me.lblOutput.Name = "lblOutput"
        Me.lblOutput.Size = New System.Drawing.Size(45, 13)
        Me.lblOutput.TabIndex = 15
        Me.lblOutput.Text = "Output: "
        '
        'btnHashCheck
        '
        Me.btnHashCheck.Location = New System.Drawing.Point(274, 65)
        Me.btnHashCheck.Name = "btnHashCheck"
        Me.btnHashCheck.Size = New System.Drawing.Size(125, 23)
        Me.btnHashCheck.TabIndex = 16
        Me.btnHashCheck.Text = "Hash a file"
        Me.btnHashCheck.UseVisualStyleBackColor = True
        '
        'PatchUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(723, 745)
        Me.Controls.Add(Me.btnHashCheck)
        Me.Controls.Add(Me.lblOutput)
        Me.Controls.Add(Me.lblPatch)
        Me.Controls.Add(Me.lblSource)
        Me.Controls.Add(Me.btnLoadScript)
        Me.Controls.Add(Me.gp_mem)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.btnOut)
        Me.Controls.Add(Me.btnSource)
        Me.Controls.Add(Me.txtOutput)
        Me.Controls.Add(Me.txtSource)
        Me.Controls.Add(Me.txtDiff)
        Me.Controls.Add(Me.btnSelectDiff)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.OutputTextBox)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTextOutput)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PatchUI"
        Me.Text = "Xdelta 3"
        Me.gp_mem.ResumeLayout(False)
        Me.gp_mem.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtTextOutput As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents OutputTextBox As System.Windows.Forms.TextBox
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnSelectDiff As System.Windows.Forms.Button
    Friend WithEvents txtDiff As System.Windows.Forms.TextBox
    Friend WithEvents txtSource As System.Windows.Forms.TextBox
    Friend WithEvents txtOutput As System.Windows.Forms.TextBox
    Friend WithEvents btnSource As System.Windows.Forms.Button
    Friend WithEvents btnOut As System.Windows.Forms.Button
    Friend WithEvents CheckExitTimer As System.Windows.Forms.Timer
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents mem_default As System.Windows.Forms.RadioButton
    Friend WithEvents mem_1GB As System.Windows.Forms.RadioButton
    Friend WithEvents mem_2GB As System.Windows.Forms.RadioButton
    Friend WithEvents gp_mem As System.Windows.Forms.GroupBox
    Friend WithEvents btnLoadScript As System.Windows.Forms.Button
    Friend WithEvents lblSource As System.Windows.Forms.Label
    Friend WithEvents lblPatch As System.Windows.Forms.Label
    Friend WithEvents lblOutput As System.Windows.Forms.Label
    Friend WithEvents btnHashCheck As System.Windows.Forms.Button

End Class
