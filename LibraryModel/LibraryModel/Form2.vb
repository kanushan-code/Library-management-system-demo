Imports System.Data.SqlClient
Public Class Form2
    Dim con2 As New SqlConnection
    Dim cmd2 As New SqlCommand
    Dim constring2 As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\GF63\Desktop\movies\LibraryModel\LibraryModel\Lib.mdf;Integrated Security=True"

    'Function add2()
    ' Dim a
    'a = TextBox3.Text + 3
    'Return a
    'End Function

    Public Sub insert2()
        'TextBox3.Text = add2()
        con2 = New SqlConnection(constring2)
        con2.Open()
        cmd2 = New SqlCommand("insert into student(name,subject,address)
        values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "')", con2)
        cmd2.ExecuteNonQuery()
        MsgBox("Data is inserted")
        con2.Close()
        display2()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        insert2()
    End Sub




    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        delete2()
    End Sub

    Public Sub delete2()
        con2 = New SqlConnection(constring2)
        con2.Open()
        cmd2 = New SqlCommand("delete from student where name ='" & TextBox1.Text & "'
", con2)
        If (cmd2.ExecuteNonQuery() > 0) Then
            MsgBox("Record is deleted")
        Else
            MsgBox("Record is not found ")
        End If
        con2.Close()
    End Sub


    Public Sub search2()
        con2 = New SqlConnection(constring2)
        con2.Open()
        Dim reader As SqlDataReader
        cmd2 = New SqlCommand("select * from student where name ='" & TextBox4.Text & "'", con2)
        reader = cmd2.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                TextBox1.Text = reader(1)
                TextBox2.Text = reader(2)
                TextBox3.Text = reader(3)
            End While
        Else
            MsgBox("Data is not found")
        End If
        con2.Close()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        search2()

    End Sub


    Public Sub display2()
        con2 = New SqlConnection(constring2)
        con2.Open()
        cmd2 = con2.CreateCommand()
        cmd2.CommandType = CommandType.Text
        cmd2.CommandText = "select * from student"
        cmd2.ExecuteNonQuery()
        Dim dt As New DataTable()
        Dim da As New SqlDataAdapter(cmd2)
        da.Fill(dt)
        DataGridView1.DataSource = dt

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        display2()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click


        Me.Close()
        Form1.Show()
    End Sub
End Class
