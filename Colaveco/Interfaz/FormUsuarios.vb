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
        RadioCorrido.Checked = True
        TextEntra.Text = ""
        TextSale.Text = ""
        TextEntra2.Text = ""
        TextSale2.Text = ""
        TextEntra3.Text = ""
        TextSale3.Text = ""
        TextEntra4.Text = ""
        TextSale4.Text = ""
        TextEntra5.Text = ""
        TextSale5.Text = ""
        TextEntra6.Text = ""
        TextSale6.Text = ""
        TextEntraC.Text = ""
        TextSaleC.Text = ""
        TextEntraC2.Text = ""
        TextSaleC2.Text = ""
        TextEntraC3.Text = ""
        TextSaleC3.Text = ""
        TextEntraC4.Text = ""
        TextSaleC4.Text = ""
        TextEntraC5.Text = ""
        TextSaleC5.Text = ""
        TextEntraC6.Text = ""
        TextSaleC6.Text = ""
        TextEntraR.Text = ""
        TextSaleR.Text = ""
        TextEntraR2.Text = ""
        TextSaleR2.Text = ""
        TextEntraR3.Text = ""
        TextSaleR3.Text = ""
        TextEntraR4.Text = ""
        TextSaleR4.Text = ""
        TextEntraR5.Text = ""
        TextSaleR5.Text = ""
        TextEntraR6.Text = ""
        TextSaleR6.Text = ""
        CheckCambiar.Checked = False
        DateCSalud.Value = Now
        listar()
        TextNombre.Focus()
    End Sub
    Private Sub listar()
        Dim u As New dUsuario
        Dim usu As Integer = Usuario.ID
        Dim lista As New ArrayList
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        If usu = 32 Or usu = 116 Or usu = 4 Or usu = 5 Or usu = 47 Or usu = 122 Then
            lista = u.listar
        Else
            lista = u.listarxusuario(usu)
        End If
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
        Dim tipomarca As Integer = 0
        If RadioCorrido.Checked = True Then
            tipomarca = 1
        ElseIf RadioCortado.Checked = True Then
            tipomarca = 2
        ElseIf RadioRotativo.Checked = True Then
            tipomarca = 3
        End If
        Dim entra As String = ""
        Dim sale As String = ""
        Dim entra2 As String = ""
        Dim sale2 As String = ""
        Dim entra3 As String = ""
        Dim sale3 As String = ""
        Dim entra4 As String = ""
        Dim sale4 As String = ""
        Dim entra5 As String = ""
        Dim sale5 As String = ""
        Dim entra6 As String = ""
        Dim sale6 As String = ""
        Dim entrac As String = ""
        Dim salec As String = ""
        Dim entrac2 As String = ""
        Dim salec2 As String = ""
        Dim entrac3 As String = ""
        Dim salec3 As String = ""
        Dim entrac4 As String = ""
        Dim salec4 As String = ""
        Dim entrac5 As String = ""
        Dim salec5 As String = ""
        Dim entrac6 As String = ""
        Dim salec6 As String = ""
        Dim entrar As String = ""
        Dim saler As String = ""
        Dim entrar2 As String = ""
        Dim saler2 As String = ""
        Dim entrar3 As String = ""
        Dim saler3 As String = ""
        Dim entrar4 As String = ""
        Dim saler4 As String = ""
        Dim entrar5 As String = ""
        Dim saler5 As String = ""
        Dim entrar6 As String = ""
        Dim saler6 As String = ""
        entra = TextEntra.Text
        sale = TextSale.Text
        entra2 = TextEntra2.Text
        sale2 = TextSale2.Text
        entra3 = TextEntra3.Text
        sale3 = TextSale3.Text
        entra4 = TextEntra4.Text
        sale4 = TextSale4.Text
        entra5 = TextEntra5.Text
        sale5 = TextSale5.Text
        entra6 = TextEntra6.Text
        sale6 = TextSale6.Text
        entrac = TextEntraC.Text
        salec = TextSaleC.Text
        entrac2 = TextEntraC2.Text
        salec2 = TextSaleC2.Text
        entrac3 = TextEntraC3.Text
        salec3 = TextSaleC3.Text
        entrac4 = TextEntraC4.Text
        salec4 = TextSaleC4.Text
        entrac5 = TextEntraC5.Text
        salec5 = TextSaleC5.Text
        entrac6 = TextEntraC6.Text
        salec6 = TextSaleC6.Text
        entrar = TextEntraR.Text
        saler = TextSaleR.Text
        entrar2 = TextEntraR2.Text
        saler2 = TextSaleR2.Text
        entrar3 = TextEntraR3.Text
        saler3 = TextSaleR3.Text
        entrar4 = TextEntraR4.Text
        saler4 = TextSaleR4.Text
        entrar5 = TextEntraR5.Text
        saler5 = TextSaleR5.Text
        entrar6 = TextEntraR6.Text
        saler6 = TextSaleR6.Text
        Dim fechacsalud As Date = DateCSalud.Value.ToString("yyyy-MM-dd")
        If TextId.Text.Trim.Length > 0 Then
            Dim u As New dUsuario
            Dim id As Long = CType(TextId.Text.Trim, Long)
            Dim feccsalud As String
            feccsalud = Format(fechacsalud, "yyyy-MM-dd")
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
            u.TIPOMARCA = tipomarca
            u.ENTRA = entra
            u.SALE = sale
            u.ENTRA2 = entra2
            u.SALE2 = sale2
            u.ENTRA3 = entra3
            u.SALE3 = sale3
            u.ENTRA4 = entra4
            u.SALE4 = sale4
            u.ENTRA5 = entra5
            u.SALE5 = sale5
            u.ENTRA6 = entra6
            u.SALE6 = sale6
            u.ENTRAC = entrac
            u.SALEC = salec
            u.ENTRAC2 = entrac2
            u.SALEC2 = salec2
            u.ENTRAC3 = entrac3
            u.SALEC3 = salec3
            u.ENTRAC4 = entrac4
            u.SALEC4 = salec4
            u.ENTRAC5 = entrac5
            u.SALEC5 = salec5
            u.ENTRAC6 = entrac6
            u.SALEC6 = salec6
            u.ENTRAR = entrar
            u.SALER = saler
            u.ENTRAR2 = entrar2
            u.SALER2 = saler2
            u.ENTRAR3 = entrar3
            u.SALER3 = saler3
            u.ENTRAR4 = entrar4
            u.SALER4 = saler4
            u.ENTRAR5 = entrar5
            u.SALER5 = saler5
            u.ENTRAR6 = entrar6
            u.SALER6 = saler6
            u.CSALUD = feccsalud
            If (u.modificar(usuario)) Then
                MsgBox("Usuario modificado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            If CheckCambiar.Checked = False Then
                MsgBox("Debe ingresar una contraseña!")
                Exit Sub
            End If
            Dim u As New dUsuario
            Dim feccsalud As String
            feccsalud = Format(fechacsalud, "yyyy-MM-dd")
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
            u.TIPOMARCA = tipomarca
            u.ENTRA = entra
            u.SALE = sale
            u.ENTRA2 = entra2
            u.SALE2 = sale2
            u.ENTRA3 = entra3
            u.SALE3 = sale3
            u.ENTRA4 = entra4
            u.SALE4 = sale4
            u.ENTRA5 = entra5
            u.SALE5 = sale5
            u.ENTRA6 = entra6
            u.SALE6 = sale6
            u.ENTRAC = entrac
            u.SALEC = salec
            u.ENTRAC2 = entrac2
            u.SALEC2 = salec2
            u.ENTRAC3 = entrac3
            u.SALEC3 = salec3
            u.ENTRAC4 = entrac4
            u.SALEC4 = salec4
            u.ENTRAC5 = entrac5
            u.SALEC5 = salec5
            u.ENTRAC6 = entrac6
            u.SALEC6 = salec6
            u.ENTRAR = entrar
            u.SALER = saler
            u.ENTRAR2 = entrar2
            u.SALER2 = saler2
            u.ENTRAR3 = entrar3
            u.SALER3 = saler3
            u.ENTRAR4 = entrar4
            u.SALER4 = saler4
            u.ENTRAR5 = entrar5
            u.SALER5 = saler5
            u.ENTRAR6 = entrar6
            u.SALER6 = saler6
            u.CSALUD = feccsalud
            If (u.guardar(Usuario)) Then
                MsgBox("Usuario guardado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub
    Private Sub guardar2()
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
        Dim tipomarca As Integer = 0
        If RadioCorrido.Checked = True Then
            tipomarca = 1
        ElseIf RadioCortado.Checked = True Then
            tipomarca = 2
        ElseIf RadioRotativo.Checked = True Then
            tipomarca = 3
        End If
        Dim entra As String = ""
        Dim sale As String = ""
        Dim entra2 As String = ""
        Dim sale2 As String = ""
        Dim entra3 As String = ""
        Dim sale3 As String = ""
        Dim entra4 As String = ""
        Dim sale4 As String = ""
        Dim entra5 As String = ""
        Dim sale5 As String = ""
        Dim entra6 As String = ""
        Dim sale6 As String = ""
        Dim entrac As String = ""
        Dim salec As String = ""
        Dim entrac2 As String = ""
        Dim salec2 As String = ""
        Dim entrac3 As String = ""
        Dim salec3 As String = ""
        Dim entrac4 As String = ""
        Dim salec4 As String = ""
        Dim entrac5 As String = ""
        Dim salec5 As String = ""
        Dim entrac6 As String = ""
        Dim salec6 As String = ""
        Dim entrar As String = ""
        Dim saler As String = ""
        Dim entrar2 As String = ""
        Dim saler2 As String = ""
        Dim entrar3 As String = ""
        Dim saler3 As String = ""
        Dim entrar4 As String = ""
        Dim saler4 As String = ""
        Dim entrar5 As String = ""
        Dim saler5 As String = ""
        Dim entrar6 As String = ""
        Dim saler6 As String = ""
        entra = TextEntra.Text
        sale = TextSale.Text
        entra2 = TextEntra2.Text
        sale2 = TextSale2.Text
        entra3 = TextEntra3.Text
        sale3 = TextSale3.Text
        entra4 = TextEntra4.Text
        sale4 = TextSale4.Text
        entra5 = TextEntra5.Text
        sale5 = TextSale5.Text
        entra6 = TextEntra6.Text
        sale6 = TextSale6.Text
        entrac = TextEntraC.Text
        salec = TextSaleC.Text
        entrac2 = TextEntraC2.Text
        salec2 = TextSaleC2.Text
        entrac3 = TextEntraC3.Text
        salec3 = TextSaleC3.Text
        entrac4 = TextEntraC4.Text
        salec4 = TextSaleC4.Text
        entrac5 = TextEntraC5.Text
        salec5 = TextSaleC5.Text
        entrac6 = TextEntraC6.Text
        salec6 = TextSaleC6.Text
        entrar = TextEntraR.Text
        saler = TextSaleR.Text
        entrar2 = TextEntraR2.Text
        saler2 = TextSaleR2.Text
        entrar3 = TextEntraR3.Text
        saler3 = TextSaleR3.Text
        entrar4 = TextEntraR4.Text
        saler4 = TextSaleR4.Text
        entrar5 = TextEntraR5.Text
        saler5 = TextSaleR5.Text
        entrar6 = TextEntraR6.Text
        saler6 = TextSaleR6.Text
        Dim fechacsalud As Date = DateCSalud.Value.ToString("yyyy-MM-dd")
        If TextId.Text.Trim.Length > 0 Then
            Dim u As New dUsuario
            Dim id As Long = CType(TextId.Text.Trim, Long)
            Dim feccsalud As String
            feccsalud = Format(fechacsalud, "yyyy-MM-dd")
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
            u.ELIMINADO = eliminado
            u.FOTO = foto
            u.TIPOMARCA = tipomarca
            u.ENTRA = entra
            u.SALE = sale
            u.ENTRA2 = entra2
            u.SALE2 = sale2
            u.ENTRA3 = entra3
            u.SALE3 = sale3
            u.ENTRA4 = entra4
            u.SALE4 = sale4
            u.ENTRA5 = entra5
            u.SALE5 = sale5
            u.ENTRA6 = entra6
            u.SALE6 = sale6
            u.ENTRAC = entrac
            u.SALEC = salec
            u.ENTRAC2 = entrac2
            u.SALEC2 = salec2
            u.ENTRAC3 = entrac3
            u.SALEC3 = salec3
            u.ENTRAC4 = entrac4
            u.SALEC4 = salec4
            u.ENTRAC5 = entrac5
            u.SALEC5 = salec5
            u.ENTRAC6 = entrac6
            u.SALEC6 = salec6
            u.ENTRAR = entrar
            u.SALER = saler
            u.ENTRAR2 = entrar2
            u.SALER2 = saler2
            u.ENTRAR3 = entrar3
            u.SALER3 = saler3
            u.ENTRAR4 = entrar4
            u.SALER4 = saler4
            u.ENTRAR5 = entrar5
            u.SALER5 = saler5
            u.ENTRAR6 = entrar6
            u.SALER6 = saler6
            u.CSALUD = feccsalud
            If (u.modificar2(Usuario)) Then
                MsgBox("Usuario modificado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            If CheckCambiar.Checked = False Then
                MsgBox("Debe ingresar una contraseña!")
                Exit Sub
            End If
            Dim u As New dUsuario
            Dim feccsalud As String
            feccsalud = Format(fechacsalud, "yyyy-MM-dd")
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
            u.ELIMINADO = eliminado
            u.FOTO = foto
            u.TIPOMARCA = tipomarca
            u.ENTRA = entra
            u.SALE = sale
            u.ENTRA2 = entra2
            u.SALE2 = sale2
            u.ENTRA3 = entra3
            u.SALE3 = sale3
            u.ENTRA4 = entra4
            u.SALE4 = sale4
            u.ENTRA5 = entra5
            u.SALE5 = sale5
            u.ENTRA6 = entra6
            u.SALE6 = sale6
            u.ENTRAC = entrac
            u.SALEC = salec
            u.ENTRAC2 = entrac2
            u.SALEC2 = salec2
            u.ENTRAC3 = entrac3
            u.SALEC3 = salec3
            u.ENTRAC4 = entrac4
            u.SALEC4 = salec4
            u.ENTRAC5 = entrac5
            u.SALEC5 = salec5
            u.ENTRAC6 = entrac6
            u.SALEC6 = salec6
            u.ENTRAR = entrar
            u.SALER = saler
            u.ENTRAR2 = entrar2
            u.SALER2 = saler2
            u.ENTRAR3 = entrar3
            u.SALER3 = saler3
            u.ENTRAR4 = entrar4
            u.SALER4 = saler4
            u.ENTRAR5 = entrar5
            u.SALER5 = saler5
            u.ENTRAR6 = entrar6
            u.SALER6 = saler6
            u.CSALUD = feccsalud
            If (u.guardar2(Usuario)) Then
                MsgBox("Usuario guardado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub
    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        If CheckCambiar.Checked = True Then
            guardar()
        Else
            guardar2()
        End If
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
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
                If u.TIPOMARCA = 1 Then
                    RadioCorrido.Checked = True
                ElseIf u.TIPOMARCA = 2 Then
                    RadioCortado.Checked = True
                ElseIf u.TIPOMARCA = 3 Then
                    RadioRotativo.Checked = True
                End If
                TextEntra.Text = u.ENTRA
                TextSale.Text = u.SALE
                TextEntra2.Text = u.ENTRA2
                TextSale2.Text = u.SALE2
                TextEntra3.Text = u.ENTRA3
                TextSale3.Text = u.SALE3
                TextEntra4.Text = u.ENTRA4
                TextSale4.Text = u.SALE4
                TextEntra5.Text = u.ENTRA5
                TextSale5.Text = u.SALE5
                TextEntra6.Text = u.ENTRA6
                TextSale6.Text = u.SALE6
                TextEntraC.Text = u.ENTRAC
                TextSaleC.Text = u.SALEC
                TextEntraC2.Text = u.ENTRAC2
                TextSaleC2.Text = u.SALEC2
                TextEntraC3.Text = u.ENTRAC3
                TextSaleC3.Text = u.SALEC3
                TextEntraC4.Text = u.ENTRAC4
                TextSaleC4.Text = u.SALEC4
                TextEntraC5.Text = u.ENTRAC5
                TextSaleC5.Text = u.SALEC5
                TextEntraC6.Text = u.ENTRAC6
                TextSaleC6.Text = u.SALEC6
                TextEntraR.Text = u.ENTRAR
                TextSaleR.Text = u.SALER
                TextEntraR2.Text = u.ENTRAR2
                TextSaleR2.Text = u.SALER2
                TextEntraR3.Text = u.ENTRAR3
                TextSaleR3.Text = u.SALER3
                TextEntraR4.Text = u.ENTRAR4
                TextSaleR4.Text = u.SALER4
                TextEntraR5.Text = u.ENTRAR5
                TextSaleR5.Text = u.SALER5
                TextEntraR6.Text = u.ENTRAR6
                TextSaleR6.Text = u.SALER6
                DateCSalud.Value = u.CSALUD
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
                If u.TIPOUSUARIO = 99 Then
                    ComboTipoUsuario.SelectedItem = Nothing
                    For Each tu In ComboTipoUsuario.Items
                        If tu.ID = u.TIPOUSUARIO Then
                            ComboTipoUsuario.SelectedItem = tu
                            Exit For
                        End If
                    Next
                End If
                If u.TIPOUSUARIO <> 99 Then
                    ComboTipoUsuario.Enabled = False
                End If
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
                If u.TIPOMARCA = 1 Then
                    RadioCorrido.Checked = True
                ElseIf u.TIPOMARCA = 2 Then
                    RadioCortado.Checked = True
                ElseIf u.TIPOMARCA = 3 Then
                    RadioRotativo.Checked = True
                End If
                TextEntra.Text = u.ENTRA
                TextSale.Text = u.SALE
                TextEntra2.Text = u.ENTRA2
                TextSale2.Text = u.SALE2
                TextEntra3.Text = u.ENTRA3
                TextSale3.Text = u.SALE3
                TextEntra4.Text = u.ENTRA4
                TextSale4.Text = u.SALE4
                TextEntra5.Text = u.ENTRA5
                TextSale5.Text = u.SALE5
                TextEntra6.Text = u.ENTRA6
                TextSale6.Text = u.SALE6
                TextEntraC.Text = u.ENTRAC
                TextSaleC.Text = u.SALEC
                TextEntraC2.Text = u.ENTRAC2
                TextSaleC2.Text = u.SALEC2
                TextEntraC3.Text = u.ENTRAC3
                TextSaleC3.Text = u.SALEC3
                TextEntraC4.Text = u.ENTRAC4
                TextSaleC4.Text = u.SALEC4
                TextEntraC5.Text = u.ENTRAC5
                TextSaleC5.Text = u.SALEC5
                TextEntraC6.Text = u.ENTRAC6
                TextSaleC6.Text = u.SALEC6
                TextEntraR.Text = u.ENTRAR
                TextSaleR.Text = u.SALER
                TextEntraR2.Text = u.ENTRAR2
                TextSaleR2.Text = u.SALER2
                TextEntraR3.Text = u.ENTRAR3
                TextSaleR3.Text = u.SALER3
                TextEntraR4.Text = u.ENTRAR4
                TextSaleR4.Text = u.SALER4
                TextEntraR5.Text = u.ENTRAR5
                TextSaleR5.Text = u.SALER5
                TextEntraR6.Text = u.ENTRAR6
                TextSaleR6.Text = u.SALER6
                DateCSalud.Value = u.CSALUD
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
                If u.TIPOUSUARIO = 99 Then
                    ComboTipoUsuario.SelectedItem = Nothing
                    For Each tu In ComboTipoUsuario.Items
                        If tu.ID = u.TIPOUSUARIO Then
                            ComboTipoUsuario.SelectedItem = tu
                            Exit For
                        End If
                    Next
                End If
                If u.TIPOUSUARIO <> 99 Then
                    ComboTipoUsuario.Enabled = False
                End If
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
                If u.TIPOMARCA = 1 Then
                    RadioCorrido.Checked = True
                ElseIf u.TIPOMARCA = 2 Then
                    RadioCortado.Checked = True
                ElseIf u.TIPOMARCA = 3 Then
                    RadioRotativo.Checked = True
                End If
                TextEntra.Text = u.ENTRA
                TextSale.Text = u.SALE
                TextEntra2.Text = u.ENTRA2
                TextSale2.Text = u.SALE2
                TextEntra3.Text = u.ENTRA3
                TextSale3.Text = u.SALE3
                TextEntra4.Text = u.ENTRA4
                TextSale4.Text = u.SALE4
                TextEntra5.Text = u.ENTRA5
                TextSale5.Text = u.SALE5
                TextEntra6.Text = u.ENTRA6
                TextSale6.Text = u.SALE6
                TextEntraC.Text = u.ENTRAC
                TextSaleC.Text = u.SALEC
                TextEntraC2.Text = u.ENTRAC2
                TextSaleC2.Text = u.SALEC2
                TextEntraC3.Text = u.ENTRAC3
                TextSaleC3.Text = u.SALEC3
                TextEntraC4.Text = u.ENTRAC4
                TextSaleC4.Text = u.SALEC4
                TextEntraC5.Text = u.ENTRAC5
                TextSaleC5.Text = u.SALEC5
                TextEntraC6.Text = u.ENTRAC6
                TextSaleC6.Text = u.SALEC6
                TextEntraR.Text = u.ENTRAR
                TextSaleR.Text = u.SALER
                TextEntraR2.Text = u.ENTRAR2
                TextSaleR2.Text = u.SALER2
                TextEntraR3.Text = u.ENTRAR3
                TextSaleR3.Text = u.SALER3
                TextEntraR4.Text = u.ENTRAR4
                TextSaleR4.Text = u.SALER4
                TextEntraR5.Text = u.ENTRAR5
                TextSaleR5.Text = u.SALER5
                TextEntraR6.Text = u.ENTRAR6
                TextSaleR6.Text = u.SALER6
                DateCSalud.Value = u.CSALUD
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
      
    End Sub

    Private Sub CheckCambiar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckCambiar.CheckedChanged
        If CheckCambiar.Checked = True Then
            TextPassword.Enabled = True
        Else
            TextPassword.Enabled = False
        End If
    End Sub

    Private Sub RadioCorrido_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioCorrido.CheckedChanged
        habilitar_grupos()
    End Sub
    Private Sub habilitar_grupos()
        If RadioCorrido.Checked = True Then
            GroupCorrido.Enabled = True
            GroupCortado.Enabled = False
            GroupRotativo.Enabled = False
        ElseIf RadioCortado.Checked = True Then
            GroupCorrido.Enabled = True
            GroupCortado.Enabled = True
            GroupRotativo.Enabled = False
        ElseIf RadioRotativo.Checked = True Then
            GroupCorrido.Enabled = True
            GroupCortado.Enabled = False
            GroupRotativo.Enabled = True
        End If
    End Sub

    Private Sub RadioCortado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioCortado.CheckedChanged
        habilitar_grupos()
    End Sub

    Private Sub RadioRotativo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioRotativo.CheckedChanged
        habilitar_grupos()
    End Sub
End Class