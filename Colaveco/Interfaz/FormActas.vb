
Public Class FormActas
#Region "Atributos"
    Private _usuario As dUsuario
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#End Region
#Region "Constructores"
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        cargarGrupos()
        cargarUsuarios()
        limpiar()
        limpiar2()
    End Sub

#End Region
    Public Sub cargarGrupos()
        Dim s As New dSectores
        Dim lista As New ArrayList
        lista = s.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each s In lista
                    ComboGrupo.Items.Add(s)
                Next
            End If
        End If
    End Sub
    Public Sub cargarUsuarios()
        Dim u As New dUsuario
        Dim listau As New ArrayList
        listau = u.listar
        If Not listau Is Nothing Then
            If listau.Count > 0 Then
                For Each u In listau
                    ComboTitular.Items.Add(u)
                    ComboTitular2.Items.Add(u)
                Next
            End If
        End If
    End Sub

    Private Sub guardarcabezal()
        If TextNumero.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado un número de acta", MsgBoxStyle.Exclamation, "Atención") : TextNumero.Focus() : Exit Sub
        Dim numero As String = TextNumero.Text.Trim
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        If TextHora.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado una hora", MsgBoxStyle.Exclamation, "Atención") : TextHora.Focus() : Exit Sub
        Dim hora As String = TextHora.Text.Trim
        Dim idgrupo As dSectores = CType(ComboGrupo.SelectedItem, dSectores)
        Dim grupo As Integer = 0
        If Not idgrupo Is Nothing Then
            grupo = idgrupo.ID
        End If
        If TextLugar.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado un lugar", MsgBoxStyle.Exclamation, "Atención") : TextLugar.Focus() : Exit Sub
        Dim lugar As String = TextLugar.Text.Trim
        If TextPresentes.Text.Trim.Length = 0 Then MsgBox("No se han ingresado los presentes", MsgBoxStyle.Exclamation, "Atención") : TextPresentes.Focus() : Exit Sub
        Dim presentes As String = TextPresentes.Text.Trim
        If TextIdActa.Text <> "" Then
            Dim a As New dActas
            Dim id As Long = TextIdActa.Text.Trim
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            a.ID = id
            a.NUMERO = numero
            a.FECHA = fec
            a.HORA = hora
            a.GRUPO = grupo
            a.LUGAR = lugar
            a.PRESENTES = presentes
            If (a.modificar(Usuario)) Then
                MsgBox("Cabezal modificado", MsgBoxStyle.Information, "Atención")

            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim a As New dActas
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            a.NUMERO = numero
            a.FECHA = fec
            a.HORA = hora
            a.GRUPO = grupo
            a.LUGAR = lugar
            a.PRESENTES = presentes
            If (a.guardar(Usuario)) Then
                MsgBox("Cabezal guardado", MsgBoxStyle.Information, "Atención")
                buscarultimoid()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub
    Private Sub buscarultimoid()
        Dim a As New dActas
        Dim id As Long = 0
        a = a.buscarultimoid()
        If Not a Is Nothing Then
            TextIdActa.Text = a.ID
        End If
    End Sub
    Private Sub agregarlinea()
        If TextIdActa.Text.Trim.Length = 0 Then MsgBox("Debe primero guardar el cabezal del acta", MsgBoxStyle.Exclamation, "Atención") : TextNumero.Focus() : Exit Sub
        If ComboTema.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado un tema", MsgBoxStyle.Exclamation, "Atención") : ComboTema.Focus() : Exit Sub
        If TextResumen.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el resúmen", MsgBoxStyle.Exclamation, "Atención") : TextResumen.Focus() : Exit Sub
        If TextResponsables.Text.Trim.Length = 0 Then MsgBox("No se han ingresado responsables", MsgBoxStyle.Exclamation, "Atención") : TextResponsables.Focus() : Exit Sub
        If ComboTitular.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado un titular", MsgBoxStyle.Exclamation, "Atención") : ComboTitular.Focus() : Exit Sub
        Dim idacta As Integer = TextIdActa.Text.Trim
        Dim tema As String = ComboTema.Text.Trim
        Dim resumen As String = TextResumen.Text.Trim
        Dim responsables As String = TextResponsables.Text.Trim
        Dim idusuario As dUsuario = CType(ComboTitular.SelectedItem, dUsuario)
        Dim titular As Integer = 0
        If Not idusuario Is Nothing Then
            titular = idusuario.ID
        End If
        Dim idusuario2 As dUsuario = CType(ComboTitular2.SelectedItem, dUsuario)
        Dim titular2 As Integer = 0
        If Not idusuario2 Is Nothing Then
            titular2 = idusuario2.ID
        Else
            titular2 = idusuario.ID
        End If
        Dim fechaplazo As Date = DatePlazo.Value.ToString("yyyy-MM-dd")
        Dim efectuado As Integer = 0
        If CheckEfectuado.Checked = True Then
            efectuado = 1
        Else
            efectuado = 0
        End If
        Dim idusu As Integer = 0
        idusu = Usuario.ID
        If TextId.Text <> "" Then
            Dim ai As New dActasItem
            Dim aif As New dActasItemFecha
            Dim id As Long = TextId.Text.Trim
            Dim fecplazo As String
            fecplazo = Format(fechaplazo, "yyyy-MM-dd")
            ai.ID = id
            ai.IDACTA = idacta
            ai.TEMA = tema
            ai.RESUMEN = resumen
            ai.RESPONSABLES = responsables
            ai.TITULAR = titular
            ai.TITULAR2 = titular2
            ai.PLAZO = fecplazo
            ai.EFECTUADO = efectuado
            aif.IDACTA = idacta
            aif.FECHA = fecplazo
            aif.USUARIO = idusu
            If (ai.modificar(Usuario)) Then
                aif.guardar(Usuario)
                'MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
                listarlineas()
                limpiar2()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim ai As New dActasItem
            Dim aif As New dActasItemFecha
            Dim fecplazo As String
            fecplazo = Format(fechaplazo, "yyyy-MM-dd")
            ai.IDACTA = idacta
            ai.TEMA = tema
            ai.RESUMEN = resumen
            ai.RESPONSABLES = responsables
            ai.TITULAR = titular
            ai.TITULAR2 = titular2
            ai.PLAZO = fecplazo
            ai.EFECTUADO = efectuado
            aif.IDACTA = idacta
            aif.FECHA = fecplazo
            aif.USUARIO = idusu
            If (ai.guardar(Usuario)) Then
                aif.guardar(Usuario)
                'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                listarlineas()
                limpiar2()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub
    Private Sub listarlineas()
        Dim ai As New dActasItem
        Dim idacta As Long = TextIdActa.Text
        Dim lista As New ArrayList
        lista = ai.listarxidacta(idacta)
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each ai In lista
                    DataGridView1(columna, fila).Value = ai.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ai.IDACTA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ai.TEMA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ai.RESUMEN
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ai.RESPONSABLES
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ai.PLAZO
                    columna = columna + 1
                    If ai.EFECTUADO = 1 Then
                        DataGridView1(columna, fila).Value = "Si"
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = "No"
                        columna = 0
                        fila = fila + 1
                    End If
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Private Sub limpiar()
        TextIdActa.Text = ""
        TextNumero.Text = ""
        DateFecha.Value = Now
        TextHora.Text = Now.ToString("HH:mm")
        ComboGrupo.Text = ""
        ComboGrupo.SelectedItem = False
        TextLugar.Text = ""
        TextPresentes.Text = ""
        ComboGrupo.Select()
    End Sub
    Private Sub limpiar2()
        TextId.Text = ""
        ComboTema.SelectedItem = "*** Sin asignar ***"
        TextResumen.Text = ""
        TextResponsables.Text = ""
        ComboTitular.Text = ""
        ComboTitular2.Text = ""
        DatePlazo.Value = Now
        CheckEfectuado.Checked = False
        ComboTema.Focus()
    End Sub

    Private Sub ButtonGuardarActa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardarActa.Click
        guardarcabezal()
    End Sub

    Private Sub ButtonGuardarItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardarItem.Click
        agregarlinea()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        limpiar()
        Dim v As New FormBuscarActas
        v.ShowDialog()

        If Not v.Actas Is Nothing Then
            Dim a As dActas = v.Actas
            TextIdActa.Text = a.ID
            TextNumero.Text = a.NUMERO
            DateFecha.Value = a.FECHA
            TextHora.Text = a.HORA
            ComboGrupo.SelectedItem = Nothing
            Dim s As dSectores
            For Each s In ComboGrupo.Items
                If s.ID = a.GRUPO Then
                    ComboGrupo.SelectedItem = s
                    Exit For
                End If
            Next
            TextLugar.Text = a.LUGAR
            TextPresentes.Text = a.PRESENTES
            listarlineas()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Tema" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ai As New dActasItem
            id = row.Cells("Id").Value
            ai.ID = id
            ai = ai.buscar
            If Not ai Is Nothing Then
                TextId.Text = ai.ID
                ComboTema.Text = ai.TEMA
                TextResumen.Text = ai.RESUMEN
                TextResponsables.Text = ai.RESPONSABLES
                Dim u As dUsuario
                For Each u In ComboTitular.Items
                    If u.ID = ai.TITULAR Then
                        ComboTitular.SelectedItem = u
                        ComboTitular.Text = u.NOMBRE
                        Exit For
                    End If
                Next
                Dim u2 As dUsuario
                For Each u2 In ComboTitular2.Items
                    If u2.ID = ai.TITULAR2 Then
                        ComboTitular2.SelectedItem = u2
                        ComboTitular2.Text = u2.NOMBRE
                        Exit For
                    End If
                Next
                DatePlazo.Value = ai.PLAZO
                If ai.EFECTUADO = 0 Then
                    CheckEfectuado.Checked = False
                Else
                    CheckEfectuado.Checked = True
                End If
            End If
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Resumen" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ai As New dActasItem
            id = row.Cells("Id").Value
            ai.ID = id
            ai = ai.buscar
            If Not ai Is Nothing Then
                TextId.Text = ai.ID
                ComboTema.Text = ai.TEMA
                TextResumen.Text = ai.RESUMEN
                TextResponsables.Text = ai.RESPONSABLES
                Dim u As dUsuario
                For Each u In ComboTitular.Items
                    If u.ID = ai.TITULAR Then
                        ComboTitular.SelectedItem = u
                        ComboTitular.Text = u.NOMBRE
                        Exit For
                    End If
                Next
                Dim u2 As dUsuario
                For Each u2 In ComboTitular2.Items
                    If u2.ID = ai.TITULAR2 Then
                        ComboTitular2.SelectedItem = u2
                        ComboTitular2.Text = u2.NOMBRE
                        Exit For
                    End If
                Next
                DatePlazo.Value = ai.PLAZO
                If ai.EFECTUADO = 0 Then
                    CheckEfectuado.Checked = False
                Else
                    CheckEfectuado.Checked = True
                End If
            End If
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Responsable" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ai As New dActasItem
            id = row.Cells("Id").Value
            ai.ID = id
            ai = ai.buscar
            If Not ai Is Nothing Then
                TextId.Text = ai.ID
                ComboTema.Text = ai.TEMA
                TextResumen.Text = ai.RESUMEN
                TextResponsables.Text = ai.RESPONSABLES
                Dim u As dUsuario
                For Each u In ComboTitular.Items
                    If u.ID = ai.TITULAR Then
                        ComboTitular.SelectedItem = u
                        ComboTitular.Text = u.NOMBRE
                        Exit For
                    End If
                Next
                Dim u2 As dUsuario
                For Each u2 In ComboTitular2.Items
                    If u2.ID = ai.TITULAR2 Then
                        ComboTitular2.SelectedItem = u2
                        ComboTitular2.Text = u2.NOMBRE
                        Exit For
                    End If
                Next
                DatePlazo.Value = ai.PLAZO
                If ai.EFECTUADO = 0 Then
                    CheckEfectuado.Checked = False
                Else
                    CheckEfectuado.Checked = True
                End If
            End If
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Plazo" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ai As New dActasItem
            id = row.Cells("Id").Value
            ai.ID = id
            ai = ai.buscar
            If Not ai Is Nothing Then
                TextId.Text = ai.ID
                ComboTema.Text = ai.TEMA
                TextResumen.Text = ai.RESUMEN
                TextResponsables.Text = ai.RESPONSABLES
                Dim u As dUsuario
                For Each u In ComboTitular.Items
                    If u.ID = ai.TITULAR Then
                        ComboTitular.SelectedItem = u
                        ComboTitular.Text = u.NOMBRE
                        Exit For
                    End If
                Next
                Dim u2 As dUsuario
                For Each u2 In ComboTitular2.Items
                    If u2.ID = ai.TITULAR2 Then
                        ComboTitular2.SelectedItem = u2
                        ComboTitular2.Text = u2.NOMBRE
                        Exit For
                    End If
                Next
                DatePlazo.Value = ai.PLAZO
                If ai.EFECTUADO = 0 Then
                    CheckEfectuado.Checked = False
                Else
                    CheckEfectuado.Checked = True
                End If
            End If
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Efectuado" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ai As New dActasItem
            id = row.Cells("Id").Value
            ai.ID = id
            ai = ai.buscar
            If Not ai Is Nothing Then
                TextId.Text = ai.ID
                ComboTema.Text = ai.TEMA
                TextResumen.Text = ai.RESUMEN
                TextResponsables.Text = ai.RESPONSABLES
                Dim u As dUsuario
                For Each u In ComboTitular.Items
                    If u.ID = ai.TITULAR Then
                        ComboTitular.SelectedItem = u
                        ComboTitular.Text = u.NOMBRE
                        Exit For
                    End If
                Next
                Dim u2 As dUsuario
                For Each u2 In ComboTitular2.Items
                    If u2.ID = ai.TITULAR2 Then
                        ComboTitular2.SelectedItem = u2
                        ComboTitular2.Text = u2.NOMBRE
                        Exit For
                    End If
                Next
                DatePlazo.Value = ai.PLAZO
                If ai.EFECTUADO = 0 Then
                    CheckEfectuado.Checked = False
                Else
                    CheckEfectuado.Checked = True
                End If
            End If
        End If
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click

        Dim result = MessageBox.Show("Desea eliminar el ítem seleccionado?", "Atención!", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Cancel Then
            Exit Sub
        ElseIf result = DialogResult.No Then
            Exit Sub
        ElseIf result = DialogResult.Yes Then
            Dim ai As New dActasItem
            If TextId.Text.Length > 0 Then
                ai.ID = TextId.Text.Trim
                ai.eliminar(Usuario)
            Else
                MsgBox("No hay ítem seleccionado!")
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        limpiar2()
        DataGridView1.Rows.Clear()
        limpiar()
    End Sub

    Private Sub ComboGrupo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboGrupo.SelectedIndexChanged
        contaractas()
    End Sub
    Private Sub contaractas()
        TextNumero.Text = ""
        Dim idgrupo As dSectores = CType(ComboGrupo.SelectedItem, dSectores)
        Dim grupo As Integer = idgrupo.ID
        Dim hoy As Date = Now
        Dim ano As Integer = 0
        ano = hoy.Year
        Dim a As New dActas
        Dim lista As New ArrayList
        Dim cantidad As Integer = 0
        Dim numero As Integer = 0
        lista = a.listarxgrupoxano(grupo, ano)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                cantidad = lista.Count
            End If
        End If
        numero = cantidad + 1
        TextNumero.Text = numero & "/" & ano
        TextLugar.Select()
    End Sub

    Private Sub ButtonImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonImprimir.Click
        imprimir()
    End Sub
    Private Sub imprimir()

    End Sub

    Private Sub ComboTema_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboTema.SelectedIndexChanged

    End Sub
End Class