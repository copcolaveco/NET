Imports System.Object
Imports System.Security.Cryptography.HashAlgorithm
Imports System.Security.Cryptography.SHA1
Public Class FormLogin
    Private _usuario As dUsuario
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property

    Public Sub buscar()
        'Dim usu As String = TextUsuario.Text.Trim
        'If usu.Length = 0 Then
        '    MsgBox("Ingrese usuario", MsgBoxStyle.Exclamation, "Atención")
        '    'TextUsuario.Focus()
        '    Exit Sub
        'End If

        'Dim clave As String = TextClave.Text.Trim
        'If clave.Length = 0 Then
        '    MsgBox("Ingrese clave", MsgBoxStyle.Exclamation, "Atención")
        '    'TextClave.Focus()
        '    Exit Sub
        'End If

        'Dim unUsuario As New dUsuario
        'unUsuario.USUARIO = usu

        'unUsuario = unUsuario.buscarPorNombre
        'If Not unUsuario Is Nothing Then
        '    If unUsuario.PASSWORD = clave Then
        '        Usuario = unUsuario
        '        Me.Close()
        '    Else
        '        MsgBox("La clave digitada no es correcta", MsgBoxStyle.Exclamation, "Atención")
        '        'TextClave.Focus()
        '        Exit Sub
        '    End If
        'Else
        '    MsgBox("El usuario buscado no existe", MsgBoxStyle.Exclamation, "Atención")
        '    'TextUsuario.Focus()
        '    Exit Sub
        'End If

    End Sub
    Public Sub buscarxpassword()
        Dim psw As String = TextPassword.Text.Trim
        If psw.Length = 0 Then
            MsgBox("Ingrese su código de acceso", MsgBoxStyle.Exclamation, "Atención")
            TextPassword.Focus()
            Exit Sub
        End If

        Dim sha As New Security.Cryptography.SHA1CryptoServiceProvider
        Dim bytestring() As Byte = System.Text.Encoding.ASCII.GetBytes(psw)
        bytestring = sha.ComputeHash(bytestring)

        Dim finalstring As String = Nothing
        For Each bt As Byte In bytestring
            finalstring &= bt.ToString("x2")
        Next

        Dim unUsuario As New dUsuario
        'unUsuario.PASSWORD = psw
        unUsuario.PASSWORD = finalstring

        unUsuario = unUsuario.buscarPorPassword
        If Not unUsuario Is Nothing Then
            Usuario = unUsuario
            Dim texto As String = ""
            'PictureBox1.Image = Image.FromFile("c:/debug/pic/" & unUsuario.FOTO)
            If unUsuario.SEXO = "F" Then
                texto = "Bienvenida"
            Else
                texto = "Bienvenido"
            End If
            Label1.Text = texto & " " & unUsuario.NOMBRE
            Timer1.Enabled = True
            'Me.Close()
        Else
            MsgBox("El código digitado no es correcto", MsgBoxStyle.Exclamation, "Atención")
            TextPassword.Focus()
            Exit Sub
        End If

    End Sub

    Private Sub ButtonAcceder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAcceder.Click
        'buscar()
        buscarxpassword()
    End Sub
    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        TextPassword.Focus()

    End Sub

    Private Sub TextUsuario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            'TextClave.Focus()
        End If
    End Sub

    Private Sub TextUsuario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextClave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            'ButtonAcceder.Focus()
            buscar()
        End If

    End Sub

    Private Sub TextCI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextPassword.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            buscarxpassword()
        End If
    End Sub

    Private Sub TextCI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextPassword.TextChanged

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Close()
    End Sub
End Class