Public Class Form1

    Dim random As New Random
    Dim car(x) As PictureBox
    Dim invisible_car_num As Integer
    Dim paused, dead, flying As Boolean
    Dim i, time_spent, k, Speed, fly, car_numbers, score, score1 As Integer

    Const x As Integer = 100
    Const max_cars As Integer = 6

    'Car Racing Car Dodging
    Dim APP_NAME As String = "Car Racing"
    Dim my_car_pic As System.Drawing.Bitmap = My.Resources.car_red

    Private Sub new_car()
        If score1 = score - 1 Then
            score += 1
            score1 += 1
            If score Mod 20 = 0 And score > 0 Then fly += 1
            If invisible_car_num = 6 Then invisible_car_num = 0
            invisible_car_num += 1

            Randomize()
            Select Case Int(Rnd() * 4) + 1
                Case 1
                    car(invisible_car_num).Visible = True
                    car(invisible_car_num).Location = New System.Drawing.Point(160, -car(invisible_car_num).Height)
                Case 2
                    car(invisible_car_num).Visible = True
                    car(invisible_car_num).Location = New System.Drawing.Point(230, -car(invisible_car_num).Height)
                Case 3
                    car(invisible_car_num).Visible = True
                    car(invisible_car_num).Location = New System.Drawing.Point(300, -car(invisible_car_num).Height)
                Case 4
                    car(invisible_car_num).Visible = True
                    car(invisible_car_num).Location = New System.Drawing.Point(370, -car(invisible_car_num).Height)
            End Select
            Label2.Text = "Your Score is : " & score
        Else
            score = score1
            Label2.Text = "PLAY FAIR AND DON'T CHEAT !!!"
            Label3.Text = "CLICK Ctrl + N TO PLAY AGAIN"
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'Auto_Label.Text = invisible_car_num
        If score - 1 = score1 Then
            Label3.Text = "Fly Times Left : " & fly
        End If
        Back.Top += 1 + car_numbers / 2
        If Back.Location = New System.Drawing.Point(0, -100) Or Back.Location.Y > -100 Then Me.Back.Location = New System.Drawing.Point(0, -540)

        For Me.i = 1 To max_cars
            car(i).Top += 1 + car_numbers
            If car(i).Location.Y > Me.ClientRectangle.Height Then car(i).Visible = False
        Next
        checkhit()
        Label4.Visible = False

        time_spent += 1
        If time_spent Mod (50 - Speed) = 0 Then new_car()
        If time_spent Mod 1000 = 0 Then
            car_numbers += 1
            If Speed < 30 Then Speed += 10
        End If
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If Not Auto_driving Then
            Select Case e.KeyCode
                Case Keys.Left
                    If my_car.Location.X > 166 And Not (dead) And Not (paused) Then
                        my_car.Left -= 70
                    End If
                Case Keys.Right
                    If my_car.Location.X < 350 And Not (dead) And Not (paused) Then
                        my_car.Left += 70
                    End If
                Case Keys.Up
                    If fly > 0 And Not (flying) And Not (dead) And Not (paused) Then
                        fly -= 1
                        flying = True
                        k = 0
                        my_car.Width += 25
                        my_car.Height += 25
                        my_car.Left -= 25 / 2
                        my_car.Top -= 25 / 2
                        k = 0
                        FlyTimer.Start()
                    ElseIf fly = 0 And dead = False Then
                        Label4.Visible = True
                    End If

                Case Keys.P
                    If Not (flying) And Not (dead) Then
                        If paused = True Then
                            Timer1.Enabled = True
                            paused = False
                            Me.Text = APP_NAME
                        Else
                            Timer1.Enabled = False
                            paused = True
                            Me.Text = APP_NAME & " - Paused"
                        End If
                    End If
            End Select
        End If

        Select Case e.KeyCode
            Case Keys.N
                If dead Then
                    new_game()
                Else
                    Me.Text = APP_NAME & " - Click Ctrl + N To Start Over"
                    My_Text_Timer.Start()
                End If
            Case Keys.O
                If dead Then
                    Panel1.Visible = True
                Else
                    Me.Text = APP_NAME & " - Click Ctrl + O To Go To Option"
                    My_Text_Timer.Start()
                End If
            Case Keys.H
                If dead Then
                    new_game()
                    Auto_drive()
                Else
                    Me.Text = APP_NAME & " - Click Ctrl + H To Watch How To Play"
                    My_Text_Timer.Start()
                End If
        End Select
        If e.KeyCode = Keys.O And e.Control = True Then
            died()
            Panel1.Visible = True
        End If
        If e.KeyCode = Keys.N And e.Control = True Then new_game()
        If e.KeyCode = Keys.H And e.Control = True Then
            new_game()
            Auto_drive()
        End If
    End Sub

    Private Sub checkhit()
        For Me.i = 1 To max_cars
            If flying = False And car(i).Visible And (my_car.Top + my_car.Height >= car(i).Top) And (my_car.Top <= car(i).Top + car(i).Height) And (my_car.Left + my_car.Width >= car(i).Left) And (my_car.Left <= car(i).Left + car(i).Width) Then
                died()
            End If
        Next
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Panel1.Location = New System.Drawing.Point(0, 0)
        Panel1.Height = Me.Height
        Panel1.Width = Me.Width

        Dim time As Integer
        If Now.Month < 10 Then
            time = Now.Year & "0" & Now.Month
        Else
            time = Now.Year & Now.Month
        End If
        If My.Settings.Time <> time Then
            My.Settings.score1 = 0
            My.Settings.score2 = 0
            My.Settings.score3 = 0
            My.Settings.score4 = 0
            My.Settings.score5 = 0
            My.Settings.Time = time
            My.Settings.Save()
        End If
        refresh_score()
        High_Scores_Timer.Start()
        Label6.Enabled = True
        dead = True
        If Not My.Settings.Version_url = "" Then Label11.Text = "Click Here To Download"
    End Sub

    Private Sub died()
        Timer1.Stop()
        Cursor.Show()
        dead = True
        Label1.Visible = True
        If Not Auto_driving Then
            If score >= My.Settings.score1 Then
                My.Settings.score5 = My.Settings.score4
                My.Settings.score4 = My.Settings.score3
                My.Settings.score3 = My.Settings.score2
                My.Settings.score2 = My.Settings.score1
                My.Settings.score1 = score
            ElseIf score >= My.Settings.score2 Then
                My.Settings.score5 = My.Settings.score4
                My.Settings.score4 = My.Settings.score3
                My.Settings.score3 = My.Settings.score2
                My.Settings.score2 = score
            ElseIf score >= My.Settings.score3 Then
                My.Settings.score5 = My.Settings.score4
                My.Settings.score4 = My.Settings.score3
                My.Settings.score3 = score
            ElseIf score >= My.Settings.score4 Then
                My.Settings.score5 = My.Settings.score4
                My.Settings.score4 = score
            ElseIf score >= My.Settings.score5 Then
                My.Settings.score5 = score
            End If
            My.Settings.Save()
            refresh_score()
        End If
        If Auto_driving Then Auto_Drive_Timer.Stop()
    End Sub

    Private Sub load_pic()
        car(1) = PictureBox1
        car(2) = PictureBox2
        car(3) = PictureBox3
        car(4) = PictureBox4
        car(5) = PictureBox5
        car(6) = PictureBox6
        For Me.i = 1 To 6
            car(i).Visible = False
        Next

        If My.Settings.my_car_pic_name = "red" Then
            my_car.Image = My.Resources.car_red

            car(1).Image = My.Resources.car_yellow
            car(2).Image = My.Resources.car_orange
            car(3).Image = My.Resources.car_green2
            car(4).Image = My.Resources.car_blue1
            car(5).Image = My.Resources.car_blue2
            car(6).Image = My.Resources.car6

        ElseIf My.Settings.my_car_pic_name = "orange" Then
            my_car.Image = My.Resources.car_orange

            car(1).Image = My.Resources.car_red
            car(2).Image = My.Resources.car_yellow
            car(3).Image = My.Resources.car_green2
            car(4).Image = My.Resources.car_blue1
            car(5).Image = My.Resources.car_blue2
            car(6).Image = My.Resources.car6

        ElseIf My.Settings.my_car_pic_name = "yellow" Then
            my_car.Image = My.Resources.car_yellow
            car(1).Image = My.Resources.car_red
            car(2).Image = My.Resources.car_orange
            car(3).Image = My.Resources.car_green2
            car(4).Image = My.Resources.car_blue1
            car(5).Image = My.Resources.car_blue2
            car(6).Image = My.Resources.car6

        ElseIf My.Settings.my_car_pic_name = "green1" Then
            my_car.Image = My.Resources.car_green1

            car(1).Image = My.Resources.car_red
            car(2).Image = My.Resources.car_yellow
            car(3).Image = My.Resources.car_orange
            car(4).Image = My.Resources.car_blue1
            car(5).Image = My.Resources.car_blue2
            car(6).Image = My.Resources.car6

        ElseIf My.Settings.my_car_pic_name = "green2" Then
            my_car.Image = My.Resources.car_green2

            car(1).Image = My.Resources.car_red
            car(2).Image = My.Resources.car_yellow
            car(3).Image = My.Resources.car_orange
            car(4).Image = My.Resources.car_blue1
            car(5).Image = My.Resources.car_blue2
            car(6).Image = My.Resources.car6

        ElseIf My.Settings.my_car_pic_name = "blue1" Then
            my_car.Image = My.Resources.car_blue1

            car(1).Image = My.Resources.car_red
            car(2).Image = My.Resources.car_yellow
            car(3).Image = My.Resources.car_orange
            car(4).Image = My.Resources.car_blue2
            car(5).Image = My.Resources.car_green2
            car(6).Image = My.Resources.car6

        ElseIf My.Settings.my_car_pic_name = "blue2" Then
            my_car.Image = My.Resources.car_blue2

            car(1).Image = My.Resources.car_red
            car(2).Image = My.Resources.car_yellow
            car(3).Image = My.Resources.car_orange
            car(4).Image = My.Resources.car_blue1
            car(5).Image = My.Resources.car_green2
            car(6).Image = My.Resources.car6

        ElseIf My.Settings.my_car_pic_name = "Fuchsia" Then
            my_car.Image = My.Resources.car6

            car(1).Image = My.Resources.car_red
            car(2).Image = My.Resources.car_yellow
            car(3).Image = My.Resources.car_orange
            car(4).Image = My.Resources.car_blue1
            car(5).Image = My.Resources.car_blue2
            car(6).Image = My.Resources.car_green2

        ElseIf My.Settings.my_car_pic_name = "gris" Then
            my_car.Image = My.Resources.car_gris

            car(1).Image = My.Resources.car_red
            car(2).Image = My.Resources.car_yellow
            car(3).Image = My.Resources.car_orange
            car(4).Image = My.Resources.car_blue2
            car(5).Image = My.Resources.car_green2
            car(6).Image = My.Resources.car6
        End If
    End Sub

    Private Sub new_game()
        Panel1.Visible = False
        Speed = 0
        k = 0
        time_spent = 0
        fly = 3
        score = -1
        score1 = -2
        car_numbers = 3
        invisible_car_num = 0

        load_pic()
        FlyTimer.Stop()

        flying = False
        dead = False
        paused = False
        Label1.Visible = False
        Auto_driving = False
        Auto_Drive_Timer.Stop()

        Back.Location = New System.Drawing.Point(0, -540)
        my_car.Location = New System.Drawing.Point(230, 348)
        my_car.Height = 100
        my_car.Width = 45

        Me.Text = APP_NAME
        Label2.Text = "Your Score is : 0"
        Timer1.Start()
        Cursor.Hide()
    End Sub

    Private Sub flytimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlyTimer.Tick
        k += 1
        If k = 65 And Auto_driving Then
            For i As Integer = 1 To 6
                While car(i).Visible And my_car.Left <= 300 And (my_car.Top + my_car.Height >= car(i).Top) And (my_car.Top <= car(i).Top + car(i).Height) And (my_car.Left + my_car.Width >= car(i).Left) And (my_car.Left <= car(i).Left + car(i).Width)
                    my_car.Left += 70
                    'MsgBox(i)
                End While
                If car(i).Visible And my_car.Left > 300 And (my_car.Top + my_car.Height >= car(i).Top) And (my_car.Top <= car(i).Top + car(i).Height) And (my_car.Left + my_car.Width >= car(i).Left) And (my_car.Left <= car(i).Left + car(i).Width) Then
                    my_car.Left -= 70
                    'MsgBox(i)
                End If
            Next
        ElseIf k = 75 Then
            my_car.Width -= 25
            my_car.Height -= 25
            my_car.Left += 25 / 2
            my_car.Top += 25 / 2
            FlyTimer.Stop()
            flying = False
        End If
    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click
        new_game()
    End Sub

    Private Sub refresh_score()
        Label6.Text = "My High Scores :" & Global.Microsoft.VisualBasic.ChrW(13)
        Label6.Text &= "1) " & My.Settings.score1 & Global.Microsoft.VisualBasic.ChrW(13)
        Label6.Text &= "2) " & My.Settings.score2 & Global.Microsoft.VisualBasic.ChrW(13)
        Label6.Text &= "3) " & My.Settings.score3 & Global.Microsoft.VisualBasic.ChrW(13)
        Label6.Text &= "4) " & My.Settings.score4 & Global.Microsoft.VisualBasic.ChrW(13)
        Label6.Text &= "5) " & My.Settings.score5 & Global.Microsoft.VisualBasic.ChrW(13)
        If My.Settings.score1 = 0 Then
            Label7.Enabled = False
        Else
            Label7.Enabled = True
        End If
    End Sub

    Private Sub Pict1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pict1.Click
        My_Car_Pict.Image = My.Resources.car_red
        My.Settings.my_car_pic_name = "red"
        My.Settings.Save()
    End Sub
    Private Sub Pict2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pict2.Click
        My_Car_Pict.Image = My.Resources.car_orange
        My.Settings.my_car_pic_name = "orange"
        My.Settings.Save()
    End Sub
    Private Sub Pict3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pict3.Click
        My_Car_Pict.Image = My.Resources.car_yellow
        My.Settings.my_car_pic_name = "yellow"
        My.Settings.Save()
    End Sub
    Private Sub Pict4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pict4.Click
        My_Car_Pict.Image = My.Resources.car_green2
        My.Settings.my_car_pic_name = "green2"
        My.Settings.Save()
    End Sub
    Private Sub Pict5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pict5.Click
        My_Car_Pict.Image = My.Resources.car_blue1
        My.Settings.my_car_pic_name = "blue1"
        My.Settings.Save()
    End Sub
    Private Sub Pict6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pict6.Click
        My_Car_Pict.Image = My.Resources.car_blue2
        My.Settings.my_car_pic_name = "blue2"
        My.Settings.Save()
    End Sub
    Private Sub Pict7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pict7.Click
        My_Car_Pict.Image = My.Resources.car6
        My.Settings.my_car_pic_name = "Fuchsia"
        My.Settings.Save()
    End Sub
    Private Sub Pict8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pict8.Click
        My_Car_Pict.Image = My.Resources.car_gris
        My.Settings.my_car_pic_name = "gris"
        My.Settings.Save()
    End Sub

    Private Sub Panel1_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel1.VisibleChanged
        refresh_score()
        If My.Settings.my_car_pic_name = "red" Then
            My_Car_Pict.Image = My.Resources.car_red
        ElseIf My.Settings.my_car_pic_name = "orange" Then
            My_Car_Pict.Image = My.Resources.car_orange
        ElseIf My.Settings.my_car_pic_name = "yellow" Then
            My_Car_Pict.Image = My.Resources.car_yellow
        ElseIf My.Settings.my_car_pic_name = "green1" Then
            My_Car_Pict.Image = My.Resources.car_green1
        ElseIf My.Settings.my_car_pic_name = "green2" Then
            My_Car_Pict.Image = My.Resources.car_green2
        ElseIf My.Settings.my_car_pic_name = "blue1" Then
            My_Car_Pict.Image = My.Resources.car_blue1
        ElseIf My.Settings.my_car_pic_name = "blue2" Then
            My_Car_Pict.Image = My.Resources.car_blue2
        ElseIf My.Settings.my_car_pic_name = "Fuchsia" Then
            My_Car_Pict.Image = My.Resources.car6
        ElseIf My.Settings.my_car_pic_name = "gris" Then
            My_Car_Pict.Image = My.Resources.car_gris
        End If

        If Panel1.Visible Then
            Me.Text = APP_NAME & " - Option"
        Else
            Me.Text = APP_NAME
        End If
    End Sub

    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click
        End
    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click
        If MessageBox.Show("Reset My High Scores ?", APP_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
            My.Settings.score1 = 0
            My.Settings.score2 = 0
            My.Settings.score3 = 0
            My.Settings.score4 = 0
            My.Settings.score5 = 0
            My.Settings.Save()
            refresh_score()
        End If
    End Sub

    Private Sub My_Text_Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles My_Text_Timer.Tick
        If Panel1.Visible Then
            Me.Text = APP_NAME & " - Option"
        ElseIf Not Panel1.Visible And Not paused Then
            Me.Text = APP_NAME
        ElseIf Not Panel1.Visible And paused Then
            Me.Text = APP_NAME & " - Paused"
        End If
        My_Text_Timer.Stop()
    End Sub

    Dim Auto_driving As Boolean

    Private Sub Auto_drive()
        If Auto_driving Then
            Auto_Drive_Timer.Stop()
            Auto_driving = False
            Auto_Label.Text = "Auto Drive - Off"
        Else
            Auto_Drive_Timer.Start()
            Auto_driving = True
            Auto_Label.Text = "Auto Drive - On"
        End If
        Cursor.Show()
    End Sub

    Private Sub Auto_Label_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Auto_Label.Click
        Auto_drive()
    End Sub

    Private Sub Auto_Drive_Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Auto_Drive_Timer.Tick
        If Not dead Then
            Dim i1 As Integer


            '160 230 300 370
            For i As Integer = 1 To 6
                If i <> 1 Then
                    i1 = i - 1
                Else
                    i1 = 6
                End If
                If (score > 300 And car(i).Top + car(i).Height >= my_car.Top - 20 Or car(i).Top + car(i).Height >= my_car.Top - 10) And car(i).Left = my_car.Left And car(i).Top + car(i).Height < my_car.Top + my_car.Height And car(i).Visible Then

                    If (((car(i1).Left = my_car.Left - 70) Or (car(i1).Left <> my_car.Left - 70 And car(i1).Left <> my_car.Left + 70)) And my_car.Left <= 300 And car(i1).Visible) Or ((score <= 1) And my_car.Left <= 300) Then
                        my_car.Left += 70
                    ElseIf ((car(i1).Left = my_car.Left + 70) Or (car(i1).Left <> my_car.Left - 70 And car(i1).Left <> my_car.Left + 70)) And car(i1).Visible And my_car.Left > 160 Then
                        my_car.Left -= 70
                    Else
                        If fly > 0 And Not (flying) And Not (dead) And Not (paused) Then
                            fly -= 1
                            flying = True
                            k = 0
                            my_car.Width += 25
                            my_car.Height += 25
                            my_car.Left -= 25 / 2
                            my_car.Top -= 25 / 2
                            k = 0
                            FlyTimer.Start()
                        ElseIf fly = 0 And dead = False Then
                            Label4.Visible = True
                        End If
                    End If

                End If

            Next
        End If
    End Sub

    Private Sub Demo_Label_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Demo_Label.Click
        new_game()
        Auto_drive()
    End Sub

    Dim nb_v_check As Integer
    Dim New_Version_Url As String
    Dim New_Version As String
    Dim My_Version As String
    Dim title = "Car Racing"
    Dim Text_From = "http://carracing3.blogspot.com/2015/07/blog-post.html"

    'Begin_Version_Url:http://:End_Version_Url
    'Version_Begin: 2.0.1.0 :Version_End
    'Begin_Top5:Top 5 Scores : (07/2015)
    '1) 0
    '2) 0
    '3) 0
    '4) 0
    '5) 0 :End_Top5

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click
        If Label11.Text = "Check For New Version !" Or Label11.Text = "Bad Internet Connection ! Check Now ?" Or Label11.Text = "No Internet Connection ! Check Now ?" Then
            nb_v_check = 0
            If My.Computer.Network.IsAvailable Then
                Label11.Text = "Checking ..."
                WebBrowser1.Navigate(Text_From)
            Else
                Label11.Text = "No Internet Connection ! Check Now ?"
            End If
        ElseIf Not My.Settings.Version_url = "" Then
            Process.Start(My.Settings.Version_url)
        End If
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        nb_v_check += 1
        If WebBrowser1.DocumentTitle = title Then
            My_Version = Me.ProductVersion.ToString.Replace(".", "")
            New_Version_Url = get_val(WebBrowser1.DocumentText, "Begin_Version_Url:", ":End_Version_Url")
            'MsgBox(New_Version_Url)
            New_Version = get_val(WebBrowser1.DocumentText, "Version_Begin: ", " :Version_End").Replace(".", "")

            If New_Version > My_Version Then
                Label11.Text = "Click Here To Download"
                My.Settings.Version_url = New_Version_Url
                My.Settings.Save()
            Else
                Label11.Text = "You Have The Newest Version"
            End If
            My.Settings.Top5 = get_val(WebBrowser1.DocumentText, "Begin_Top5:", ":End_Top5")
            My.Settings.Save()
            Label6.Text = My.Settings.Top5
        ElseIf Not WebBrowser1.DocumentTitle = title Then
            If nb_v_check < 3 Then WebBrowser1.Navigate(Text_From)
            If nb_v_check >= 3 Then Label11.Text = "Bad Internet Connection ! Check Now ?"
        End If
    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click
        Dialog2.ShowDialog()
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        Dialog1.ShowDialog()
    End Sub

    Function get_val(ByVal str As String, ByVal fromstr As String, ByVal tostr As String)

        Dim search_min As String = InStr(str, fromstr)
        Dim search_max As String = InStr(str, tostr)

        Try
            get_val = str.Substring((search_min + fromstr.Length) - 1, str.Length - (search_min + fromstr.Length + (str.Length - search_max)))
        Catch ex As Exception
        End Try
    End Function

    Dim top5_title = title
    Dim Top5_From = Text_From

    Private Sub High_Scores_Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles High_Scores_Timer.Tick
        If InStr(Label6.Text, "My") Then
            Label6.Text = My.Settings.Top5
        Else
            refresh_score()
        End If
    End Sub

    Private Sub Label13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label13.Click
        WebBrowser2.Navigate(Top5_From)
    End Sub

    Private Sub WebBrowser2_DocumentCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser2.DocumentCompleted
        If WebBrowser2.DocumentTitle = top5_title Then
            My.Settings.Top5 = get_val(WebBrowser2.DocumentText, "Begin_Top5:", ":End_Top5")
            My.Settings.Save()
            Label6.Text = My.Settings.Top5
        End If
    End Sub
End Class