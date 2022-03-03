Imports System.Windows.Forms

Public Class Dialog2

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.Close()
    End Sub

    Private Sub Link_FB_Friend_Rq_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Link_FB_Friend_Rq.LinkClicked
        Process.Start("http://www.facebook.com/Rami.majdoub.3")
    End Sub

    Private Sub Link_FB_Page_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Link_FB_Page.LinkClicked
        Process.Start("https://www.facebook.com/794619710602488")
    End Sub

    Private Sub Link_Youtube_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Link_Youtube.LinkClicked
        Process.Start("http://Youtube.com/user/Rami468")
    End Sub

    Private Sub Link_Deal_OR_NoDeal_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Link_Deal_OR_NoDeal.LinkClicked
        Process.Start("https://www.facebook.com/download/370392163150756/Deal%20OR%20NoDeal.rar?refid=17")
    End Sub

    Private Sub Link_TTCach_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Link_TTCach.LinkClicked
        Process.Start("https://www.facebook.com/download/1581461062107210/TTCach.rar?refid=17")
    End Sub

    Private Sub Dialog2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Location = New System.Drawing.Point((Me.ClientRectangle.Width - Label1.Width) / 2, 10)
        Link_FB_Friend_Rq.Location = New System.Drawing.Point((Me.ClientRectangle.Width - Link_FB_Friend_Rq.Width) / 2, 40)
        Link_FB_Page.Location = New System.Drawing.Point((Me.ClientRectangle.Width - Link_FB_Page.Width) / 2, 70)
        Link_Youtube.Location = New System.Drawing.Point((Me.ClientRectangle.Width - Link_Youtube.Width) / 2, 100)
        Link_Deal_OR_NoDeal.Location = New System.Drawing.Point((Me.ClientRectangle.Width - Link_Deal_OR_NoDeal.Width) / 2, 130)
        Link_TTCach.Location = New System.Drawing.Point((Me.ClientRectangle.Width - Link_TTCach.Width) / 2, 160)
        OK_Button.Left = (Me.ClientRectangle.Width - OK_Button.Width) / 2
        Left = Form1.Left + (Form1.Width - Me.Width) / 2
        Top = Form1.Top + (Form1.Height - Me.Height) / 2
    End Sub
End Class
