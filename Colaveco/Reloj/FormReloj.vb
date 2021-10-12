Imports System.Object
Imports System.Security.Cryptography.HashAlgorithm
Imports System.Security.Cryptography.SHA1
Public Class FormReloj

#Region "Constructores"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Timer1.Enabled = True
    End Sub

#End Region

    Public Sub limpiar()
        TextPassword.Text = ""
        'Label2.Text = ""
        'Timer2.Enabled = False
    End Sub
    Public Sub limpiar2()
        'TextPassword.Text = ""
        Label2.Text = ""
        Timer2.Enabled = False
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label1.Text = Now
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextPassword.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            marcar()
        End If
    End Sub

    Private Sub marcar()
        Dim pws As String
        Dim usuario As Integer
        Dim marca As Date
        Dim marca2 As String
        Dim nombre As String = ""
        Dim tipomarca As Integer = 0
        Dim lista As New ArrayList
        If TextPassword.Text <> "" Then
            pws = TextPassword.Text.Trim
            Dim u As New dUsuario

            Dim sha As New Security.Cryptography.SHA1CryptoServiceProvider
            Dim bytestring() As Byte = System.Text.Encoding.ASCII.GetBytes(pws)
            bytestring = sha.ComputeHash(bytestring)

            Dim finalstring As String = Nothing
            For Each bt As Byte In bytestring
                finalstring &= bt.ToString("x2")
            Next

            'u.PASSWORD = pws
            u.PASSWORD = finalstring
            u = u.buscarPorPassword()
            If Not u Is Nothing Then
                Dim m As New dMarcas
                m.USUARIO = u.ID
                lista = m.buscarultima(m.USUARIO)
                If Not lista Is Nothing Then
                    If lista.Count > 0 Then
                        For Each m In lista
                            If m.TIPOMARCA = 0 Then
                                tipomarca = 1
                            Else
                                tipomarca = 0
                            End If
                        Next
                    End If
                Else
                    tipomarca = 1
                End If
                Dim m2 As New dMarcas
                usuario = u.ID
                nombre = u.NOMBRE
                marca = Now.ToString("yyyy-MM-dd HH:mm:ss")
                marca2 = Format(marca, "yyyy-MM-dd HH:mm:ss")
                m2.USUARIO = usuario
                m2.MARCA = marca2
                m2.TIPOMARCA = tipomarca
                m2.guardar()
                If tipomarca = 0 Then
                    Label2.Text = "SALIDA - " & nombre
                Else
                    Label2.Text = "ENTRADA - " & nombre
                End If
                limpiar()
                Timer2.Enabled = True
                m = Nothing
                m2 = Nothing
            Else
                MsgBox("La cédula ingresada no es correcta!")
            End If
        End If

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        limpiar2()
    End Sub

    Private Sub TextBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBuscar.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            listar()
            TextBuscar.Text = ""
        End If
    End Sub

    Private Sub TextBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBuscar.TextChanged

    End Sub

    Private Sub ButtonMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonMostrar.Click
        listar()
        TextBuscar.Text = ""
    End Sub

    Private Sub listar()
        'Dim pws As String
        Dim id As Integer
        Dim tipomarca As Integer = 0
        Dim lista As New ArrayList
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        If TextBuscar.Text <> "" Then
            'pws = TextBuscar.Text.Trim
            id = TextBuscar.Text.Trim

            'Dim sha As New Security.Cryptography.SHA1CryptoServiceProvider
            'Dim bytestring() As Byte = System.Text.Encoding.ASCII.GetBytes(pws)
            'bytestring = sha.ComputeHash(bytestring)

            'Dim finalstring As String = Nothing
            'For Each bt As Byte In bytestring
            '    finalstring &= bt.ToString("x2")
            'Next


            Dim u As New dUsuario
            'u.PASSWORD = finalstring
            u.ID = id
            'u = u.buscarPorPassword()
            u = u.buscar()
            If Not u Is Nothing Then
                Dim m As New dMarcas
                m.USUARIO = u.ID
                lista = m.buscarultimas200(m.USUARIO)
                DataGridView1.Rows.Clear()
                DataGridView1.Rows.Add(lista.Count)
                If Not lista Is Nothing Then
                    If lista.Count > 0 Then
                        For Each m In lista
                            DataGridView1(columna, fila).Value = m.ID
                            columna = columna + 1
                            DataGridView1(columna, fila).Value = m.MARCA
                            columna = columna + 1
                            If m.TIPOMARCA = 0 Then
                                DataGridView1(columna, fila).Value = "Salida"
                                columna = columna + 1
                            Else
                                DataGridView1(columna, fila).Value = "Entrada"
                                columna = columna + 1
                            End If
                            fila = fila + 1
                            columna = 0
                        Next
                    End If
                End If
            Else
                MsgBox("El password ingresado no es correcto!")
            End If
        End If
    End Sub

    Private Sub FormReloj_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub InformesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextPassword.TextChanged

    End Sub
End Class