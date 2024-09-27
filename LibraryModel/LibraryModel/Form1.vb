Imports System.Data.SqlClient
Public Class Form1
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim constring As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\GF63\Desktop\movies\LibraryModel\LibraryModel\Lib.mdf;Integrated Security=True"

    Function add()
        Dim a
        a = TextBox3.Text + 3
        Return a
    End Function

    Public Sub insert()
        TextBox3.Text = add()
        con = New SqlConnection(constring)
        con.Open()
        cmd = New SqlCommand("insert into book(name,regno,marks)
        values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "')", con)
        cmd.ExecuteNonQuery()
        MsgBox("Data is inserted")
        con.Close()
        display()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        insert()
    End Sub




    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        delete()
    End Sub

    Public Sub delete()
        con = New SqlConnection(constring)
        con.Open()
        cmd = New SqlCommand("delete from book where name ='" & TextBox1.Text & "'
", con)
        If (cmd.ExecuteNonQuery() > 0) Then
            MsgBox("Record is deleted")
        Else
            MsgBox("Record is not found ")
        End If
        con.Close()
    End Sub


    Public Sub search()
        con = New SqlConnection(constring)
        con.Open()
        Dim reader As SqlDataReader
        cmd = New SqlCommand("select * from book where name ='" & TextBox4.Text & "'", con)
        reader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                TextBox1.Text = reader(1)
                TextBox2.Text = reader(2)
                TextBox3.Text = reader(3)
            End While
        Else
            MsgBox("Data is not found")
        End If
        con.Close()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        search()

    End Sub


    Public Sub display()
        con = New SqlConnection(constring)
        con.Open()
        cmd = con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select * from book"
        cmd.ExecuteNonQuery()
        Dim dt As New DataTable()
        Dim da As New SqlDataAdapter(cmd)
        da.Fill(dt)
        DataGridView1.DataSource = dt

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        display()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click



        Form2.Show()
    End Sub
End Class
