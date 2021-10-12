Public Class FormUsuarios
    Private _usuario As dUsuario
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#Region "Constructores"
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        cargarSexo()
        cargarTipoUsuario()
        cargarSector()
        limpiar()
    End Sub
#End Region
    Private Sub cargarTipoUsuario()
        Dim tu As New dTipoUsuario
        Dim lista As New ArrayList
        lista = tu.listarcargos
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each tu In lista
                    ComboTipoUsuario.Items.Add(tu)
                Next
            End If
        End If
    End Sub
    Private Sub cargarSector()
        Dim s As New dSectores
        Dim lista As New ArrayList
        lista = s.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each s In lista
                    ComboSector.Items.Add(s)
                Next
            End If
        End If
    End Sub
    Private Sub cargarSexo()
        ComboSexo.Items.Add("F")
        ComboSexo.Items.Add("M")
    End Sub
    Private Sub limpiar()
        TextId.Text = ""
        TextNombre.Text = ""
        ComboSexo.Text = ""
        TextCI.Text = ""
        ComboTipoUsuario.Text = ""
        ComboSector.Text = ""
        TextUsuario.Text = ""
        TextPassword.Text = ""
        CheckEliminado.Checked = False
        TextFoto.Text = ""
        TextEntrada.Text = ""
        TextSalida.Text = ""
        listar()
        TextNombre.Focus()
    End Sub
    Private Sub listar()
        Dim u As New dUsuario
        Dim lista As New ArrayList
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        lista = u.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridView1.Rows.Clear()
                DataGridView1.Rows.Add(lista.Count)
                For Each u In lista
                    DataGridView1(columna, fila).Value = u.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = u.NOMBRE
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = u.SEXO
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = u.CI
                    fila = fila + 1
                    columna = 0
                Next
            End If
        End If
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()
    End Sub
    Private Sub guardar()
        
        If TextNombre.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el nombre", MsgBoxStyle.Exclamation, "Atención") : TextNombre.Focus() : Exit Sub
        Dim nombre As String = TextNombre.Text.Trim
        If ComboSexo.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el sexo", MsgBoxStyle.Exclamation, "Atención") : ComboSexo.Focus() : Exit Sub
        Dim sexo As String = ComboSexo.Text
        If TextCI.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el documento de identidad", MsgBoxStyle.Exclamation, "Atención") : TextCI.Focus() : Exit Sub
        Dim ci As String = TextCI.Text.Trim
        Dim tu As dTipoUsuario = CType(ComboTipoUsuario.SelectedItem, dTipoUsuario)
        Dim s As dSectores = CType(ComboSector.SelectedItem, dSectores)
        If TextUsuario.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el usuario", MsgBoxStyle.Exclamation, "Atención") : TextUsuario.Focus() : Exit Sub
        Dim _usuario As String = TextUsuario.Text
        If TextPassword.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el password", MsgBoxStyle.Exclamation, "Atención") : TextPassword.Focus() : Exit Sub
        Dim password As String = TextPassword.Text
        Dim eliminado As Integer = 0
        If CheckEliminado.Checked = True Then
            eliminado = 1
        End If
        Dim foto As String = ""
        If TextFoto.Text <> "" Then
            foto = TextFoto.Text.Trim
        Else
            foto = "100.jpg"
        End If
        Dim entra As String = ""
        Dim sale As String = ""
        entra = TextEntrada.Text
        sale = TextSalida.Text
        If TextId.Text.Trim.Length > 0 Then
            Dim u As New dUsuario
            Dim id As Long = CType(TextId.Text.Trim, Long)
            u.ID = id
            u.NOMBRE = nombre
            u.SEXO = sexo
            u.CI = ci
            If Not tu Is Nothing Then
                u.TIPOUSUARIO = tu.ID
            Else
                MsgBox("No se ha ingresado el tipo de usuario", MsgBoxStyle.Exclamation, "Atención") : TextPassword.Focus() : Exit Sub
            End If
            If Not s Is Nothing Then
                u.SECTOR = s.ID
            Else
                MsgBox("No se ha ingresado el sector", MsgBoxStyle.Exclamation, "Atención") : TextPassword.Focus() : Exit Sub
            End If
            u.USUARIO = _usuario
            u.PASSWORD = password
            u.ELIMINADO = eliminado
            u.FOTO = foto
            u.ENTRA = entra
            u.SALE = sale
            If (u.modificar(usuario)) Then
                MsgBox("Usuario modificado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim u As New dUsuario
            u.NOMBRE = nombre
            u.SEXO = sexo
            u.CI = ci
            If Not tu Is Nothing Then
                u.TIPOUSUARIO = tu.ID
            Else
                MsgBox("No se ha ingresado el tipo de usuario", MsgBoxStyle.Exclamation, "Atención") : TextPassword.Focus() : Exit Sub
            End If
            If Not s Is Nothing Then
                u.SECTOR = s.ID
            Else
                MsgBox("No se ha ingresado el sector", MsgBoxStyle.Exclamation, "Atención") : TextPassword.Focus() : Exit Sub
            End If
            u.USUARIO = _usuario
            u.PASSWORD = password
            u.ELIMINADO = eliminado
            u.FOTO = foto
            u.ENTRA = entra
            u.SALE = sale
            If (u.guardar(usuario)) Then
                MsgBox("Usuario guardado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Nombre" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim u As New dUsuario
            id = row.Cells("Id").Value
            u.ID = id
            u = u.buscar
            If Not u Is Nothing Then
                TextId.Text = u.ID
                TextNombre.Text = u.NOMBRE
                ComboSexo.Text = u.SEXO
                TextCI.Text = u.CI
                Dim tu As dTipoUsuario
                ComboTipoUsuario.SelectedItem = Nothing
                For Each tu In ComboTipoUsuario.Items
                    If tu.ID = u.TIPOUSUARIO Then
                        ComboTipoUsuario.SelectedItem = tu
                        Exit For
                    End If
                Next
                Dim s As dSectores
                ComboSector.SelectedItem = Nothing
                For Each s In ComboSector.Items
                    If s.ID = u.SECTOR Then
                        ComboSector.SelectedItem = s
                        Exit For
                    End If
                Next
                TextUsuario.Text = u.USUARIO
                TextPassword.Text = u.PASSWORD
                If u.ELIMINADO = 1 Then
                    CheckEliminado.Checked = True
                Else
                    CheckEliminado.Checked = False
                End If
                TextFoto.Text = u.FOTO
                TextEntrada.Text = u.ENTRA
                TextSalida.Text = u.SALE
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Sexo" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim u As New dUsuario
            id = row.Cells("Id").Value
            u.ID = id
            u = u.buscar
            If Not u Is Nothing Then
                TextId.Text = u.ID
                TextNombre.Text = u.NOMBRE
                ComboSexo.Text = u.SEXO
                TextCI.Text = u.CI
                Dim tu As dTipoUsuario
                ComboTipoUsuario.SelectedItem = Nothing
                For Each tu In ComboTipoUsuario.Items
                    If tu.ID = u.TIPOUSUARIO Then
                        ComboTipoUsuario.SelectedItem = tu
                        Exit For
                    End If
                Next
                Dim s As dSectores
                ComboSector.SelectedItem = Nothing
                For Each s In ComboSector.Items
                    If s.ID = u.SECTOR Then
                        ComboSector.SelectedItem = s
                        Exit For
                    End If
                Next
                TextUsuario.Text = u.USUARIO
                TextPassword.Text = u.PASSWORD
                If u.ELIMINADO = 1 Then
                    CheckEliminado.Checked = True
                Else
                    CheckEliminado.Checked = False
                End If
                TextFoto.Text = u.FOTO
                TextEntrada.Text = u.ENTRA
                TextSalida.Text = u.SALE
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "CI" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim u As New dUsuario
            id = row.Cells("Id").Value
            u.ID = id
            u = u.buscar
            If Not u Is Nothing Then
                TextId.Text = u.ID
                TextNombre.Text = u.NOMBRE
                ComboSexo.Text = u.SEXO
                TextCI.Text = u.CI
                Dim tu As dTipoUsuario
                ComboTipoUsuario.SelectedItem = Nothing
                For Each tu In ComboTipoUsuario.Items
                    If tu.ID = u.TIPOUSUARIO Then
                        ComboTipoUsuario.SelectedItem = tu
                        Exit For
                    End If
                Next
                Dim s As dSectores
                ComboSector.SelectedItem = Nothing
                For Each s In ComboSector.Items
                    If s.ID = u.SECTOR Then
                        ComboSector.SelectedItem = s
                        Exit For
                    End If
                Next
                TextUsuario.Text = u.USUARIO
                TextPassword.Text = u.PASSWORD
                If u.ELIMINADO = 1 Then
                    CheckEliminado.Checked = True
                Else
                    CheckEliminado.Checked = False
                End If
                TextFoto.Text = u.FOTO
                TextEntrada.Text = u.ENTRA
                TextSalida.Text = u.SALE
            End If
        End If
    End Sub
End Class