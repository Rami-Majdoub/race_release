<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog2
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
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Link_FB_Page = New System.Windows.Forms.LinkLabel()
        Me.Link_Youtube = New System.Windows.Forms.LinkLabel()
        Me.Link_Deal_OR_NoDeal = New System.Windows.Forms.LinkLabel()
        Me.Link_TTCach = New System.Windows.Forms.LinkLabel()
        Me.Link_FB_Friend_Rq = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OK_Button.Location = New System.Drawing.Point(62, 190)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(180, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "This Game Is By Rami Majdoub" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Link_FB_Page
        '
        Me.Link_FB_Page.AutoSize = True
        Me.Link_FB_Page.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Link_FB_Page.Location = New System.Drawing.Point(32, 70)
        Me.Link_FB_Page.Name = "Link_FB_Page"
        Me.Link_FB_Page.Size = New System.Drawing.Size(118, 15)
        Me.Link_FB_Page.TabIndex = 2
        Me.Link_FB_Page.TabStop = True
        Me.Link_FB_Page.Text = "Visit Facebook Page"
        '
        'Link_Youtube
        '
        Me.Link_Youtube.AutoSize = True
        Me.Link_Youtube.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Link_Youtube.Location = New System.Drawing.Point(28, 100)
        Me.Link_Youtube.Name = "Link_Youtube"
        Me.Link_Youtube.Size = New System.Drawing.Size(126, 15)
        Me.Link_Youtube.TabIndex = 3
        Me.Link_Youtube.TabStop = True
        Me.Link_Youtube.Text = "Visit Youtube Channel"
        '
        'Link_Deal_OR_NoDeal
        '
        Me.Link_Deal_OR_NoDeal.AutoSize = True
        Me.Link_Deal_OR_NoDeal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Link_Deal_OR_NoDeal.Location = New System.Drawing.Point(24, 130)
        Me.Link_Deal_OR_NoDeal.Name = "Link_Deal_OR_NoDeal"
        Me.Link_Deal_OR_NoDeal.Size = New System.Drawing.Size(158, 15)
        Me.Link_Deal_OR_NoDeal.TabIndex = 4
        Me.Link_Deal_OR_NoDeal.TabStop = True
        Me.Link_Deal_OR_NoDeal.Text = "Download Deal OR NoDeal"
        '
        'Link_TTCach
        '
        Me.Link_TTCach.AutoSize = True
        Me.Link_TTCach.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Link_TTCach.Location = New System.Drawing.Point(39, 160)
        Me.Link_TTCach.Name = "Link_TTCach"
        Me.Link_TTCach.Size = New System.Drawing.Size(111, 15)
        Me.Link_TTCach.TabIndex = 5
        Me.Link_TTCach.TabStop = True
        Me.Link_TTCach.Text = "Download TT Cach"
        '
        'Link_FB_Friend_Rq
        '
        Me.Link_FB_Friend_Rq.AutoSize = True
        Me.Link_FB_Friend_Rq.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Link_FB_Friend_Rq.Location = New System.Drawing.Point(12, 40)
        Me.Link_FB_Friend_Rq.Name = "Link_FB_Friend_Rq"
        Me.Link_FB_Friend_Rq.Size = New System.Drawing.Size(180, 15)
        Me.Link_FB_Friend_Rq.TabIndex = 6
        Me.Link_FB_Friend_Rq.TabStop = True
        Me.Link_FB_Friend_Rq.Text = "Send Facebook Friend Request"
        '
        'Dialog2
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.OK_Button
        Me.ClientSize = New System.Drawing.Size(202, 229)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.Link_FB_Friend_Rq)
        Me.Controls.Add(Me.Link_TTCach)
        Me.Controls.Add(Me.Link_Deal_OR_NoDeal)
        Me.Controls.Add(Me.Link_Youtube)
        Me.Controls.Add(Me.Link_FB_Page)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Dialog2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About ..."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Link_FB_Page As System.Windows.Forms.LinkLabel
    Friend WithEvents Link_Youtube As System.Windows.Forms.LinkLabel
    Friend WithEvents Link_Deal_OR_NoDeal As System.Windows.Forms.LinkLabel
    Friend WithEvents Link_TTCach As System.Windows.Forms.LinkLabel
    Friend WithEvents Link_FB_Friend_Rq As System.Windows.Forms.LinkLabel

End Class
