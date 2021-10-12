Public Class FormPlanAC
    Private _usuario As dUsuario
    Private _idac As Long
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
    Public Sub New(ByVal u As dUsuario, ByVal id_ac As Long)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        _idac = id_ac
        cargarComboResponsable()
        If _idac <> 0 Then
            cargarLista2()
        Else
            cargarLista()
        End If
        limpiar()
        TextNumeroAC.Text = _idac
        TextAccion.Focus()
    End Sub
    Public Sub cargarComboResponsable()
        Dim u As New dUsuario
        Dim lista As New ArrayList
        lista = u.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each u In lista
                    ComboResponsable.Items.Add(u)
                Next
            End If
        End If
    End Sub
    Public Sub cargarLista()
        Dim pac As New dPlanAC
        Dim lista As New ArrayList
        lista = pac.listar
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each pac In lista
                    DataGridView1(columna, fila).Value = pac.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = pac.IDAC
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = pac.ACCION
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Public Sub cargarLista2()
        Dim pac As New dPlanAC
        Dim lista As New ArrayList
        lista = pac.listarxidac(_idac)
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each pac In lista
                    DataGridView1(columna, fila).Value = pac.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = pac.IDAC
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = pac.ACCION
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Public Sub limpiar()
        TextId.Text = ""
        TextNumeroAC.Text = ""
        TextAccion.Text = ""
        ComboResponsable.Text = ""
        ComboResponsable.SelectedItem = Nothing
        ComboEfectuado.Text = ""
        ComboEfectuado.SelectedItem = Nothing
        DateFecha.Value = Now
        TextAccion.Focus()
    End Sub
    Public Sub limpiar2()
        TextId.Text = ""
        TextAccion.Text = ""
        ComboResponsable.Text = ""
        ComboResponsable.SelectedItem = Nothing
        ComboEfectuado.Text = ""
        ComboEfectuado.SelectedItem = Nothing
        DateFecha.Value = Now
        TextAccion.Focus()
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Numero" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim pac As New dPlanAC
            id = row.Cells("Id").Value
            pac.ID = id
            pac = pac.buscar
            If Not pac Is Nothing Then
                TextId.Text = pac.ID
                TextNumeroAC.Text = pac.IDAC
                TextAccion.Text = pac.ACCION
                ComboResponsable.SelectedItem = Nothing
                Dim u As dUsuario
                For Each u In ComboResponsable.Items
                    If u.ID = pac.RESPONSABLE Then
                        ComboResponsable.SelectedItem = u
                        Exit For
                    End If
                Next
                If pac.EFECTUADO = 1 Then
                    ComboEfectuado.Text = "Si"
                Else
                    ComboEfectuado.Text = "No"
                End If
                DateFecha.Value = pac.FECHA
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Accion" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim pac As New dPlanAC
            id = row.Cells("Id").Value
            pac.ID = id
            pac = pac.buscar
            If Not pac Is Nothing Then
                TextId.Text = pac.ID
                TextNumeroAC.Text = pac.IDAC
                TextAccion.Text = pac.ACCION
                ComboResponsable.SelectedItem = Nothing
                Dim u As dUsuario
                For Each u In ComboResponsable.Items
                    If u.ID = pac.RESPONSABLE Then
                        ComboResponsable.SelectedItem = u
                        Exit For
                    End If
                Next
                If pac.EFECTUADO = 1 Then
                    ComboEfectuado.Text = "Si"
                Else
                    ComboEfectuado.Text = "No"
                End If
                DateFecha.Value = pac.FECHA
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub ButtonNueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNueva.Click
        limpiar2()
        cargarLista()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        Dim numero As Long = TextNumeroAC.Text.Trim
        Dim accion As String = TextAccion.Text.Trim
        Dim idresponsable As dUsuario = CType(ComboResponsable.SelectedItem, dUsuario)
        Dim efectuado As Integer = 0
        If ComboEfectuado.Text <> "" Then
            If ComboEfectuado.Text = "Si" Then
                efectuado = 1
            Else
                efectuado = 0
            End If
        Else
            MsgBox("Debe seleccionar si está efectuado o no!")
            Exit Sub
            ComboEfectuado.Focus()
        End If
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        If TextId.Text.Trim.Length > 0 Then
            Dim pac As New dPlanAC
            Dim id As Long = CType(TextId.Text.Trim, Long)
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            pac.ID = id
            pac.IDAC = numero
            pac.ACCION = accion
            pac.RESPONSABLE = idresponsable.ID
            pac.EFECTUADO = efectuado
            pac.FECHA = fec
            If Usuario.USUARIO = "CA" Then
                If (pac.modificar(Usuario)) Then
                    MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                MsgBox("No tiene permisos para modificar el registro.", MsgBoxStyle.Information, "Atención")
            End If
        Else
            Dim pac As New dPlanAC
            'Dim id As Long = CType(TextId.Text.Trim, Long)
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            pac.IDAC = numero
            pac.ACCION = accion
            pac.RESPONSABLE = idresponsable.ID
            pac.EFECTUADO = efectuado
            pac.FECHA = fec
            If (pac.guardar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        cargarLista()
        limpiar2()
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If TextId.Text <> "" Then
            If Usuario.USUARIO = "CA" Then
                If MsgBox("El registro será eliminado, ¿desea continuar?", MsgBoxStyle.OkCancel, "Atención") = MsgBoxResult.Ok Then
                    Dim pac As New dPlanAC
                    Dim id As Long = CType(TextId.Text, Long)
                    pac.ID = id
                    If (pac.eliminar(Usuario)) Then
                        MsgBox("Registro eliminado", MsgBoxStyle.Information, "Atención")
                    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                    End If
                End If
            Else
                MsgBox("No tiene permisos para modificar el registro.", MsgBoxStyle.Information, "Atención")
            End If
        End If
        limpiar2()
        cargarLista()
    End Sub
End Class