Public Class FormLicenciaAnual
#Region "Atributos"
    Private _usuario As dUsuario
    Private _anio As Integer
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
        calcularano()
        cargarUsuarios()
        cargarLista()
    End Sub
#End Region
    Private Sub cargarUsuarios()
        Dim u As New dUsuario
        Dim lista As New ArrayList
        lista = u.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each u In lista
                    ComboFuncionarios.Items.Add(u)
                Next
            End If
        End If
    End Sub
    Private Sub limpiar()
        TextId.Text = ""
        ComboFuncionarios.SelectedItem = False
        ComboFuncionarios.Text = ""
        TextDias.Text = ""
        ComboFuncionarios.Focus()
    End Sub
    Private Sub calcularano()
        Dim hoy As Date = Now
        Dim ano As Integer = 0
        ano = hoy.Year
        NumericAno.Value = ano
    End Sub
    Private Sub cargarLista()
        DataGridView1.Rows.Clear()
        Dim l As New dLicenciaAnual
        Dim lista As New ArrayList
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        lista = l.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridView1.Rows.Clear()
                DataGridView1.Rows.Add(lista.Count)
                For Each l In lista
                    DataGridView1(columna, fila).Value = l.ID
                    columna = columna + 1
                    Dim u As New dUsuario
                    u.ID = l.FUNCIONARIO
                    u = u.buscar
                    DataGridView1(columna, fila).Value = u.NOMBRE
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = l.DIAS
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = l.ANO
                    columna = 0
                    fila = fila + 1
                Next
            End If
        End If

    End Sub
    Private Sub guardar()
        Dim funcionario As dUsuario = CType(ComboFuncionarios.SelectedItem, dUsuario)
        Dim idfuncionario As Integer = 0
        If Not funcionario Is Nothing Then
            idfuncionario = funcionario.ID
        Else
            MsgBox("No se ha seleccionado funcionario", MsgBoxStyle.Exclamation, "Atención") : ComboFuncionarios.Focus() : Exit Sub
        End If
        If TextDias.Text.Trim.Length = 0 Then MsgBox("No se han ingresado los días", MsgBoxStyle.Exclamation, "Atención") : TextDias.Focus() : Exit Sub
        Dim dias As Integer = TextDias.Text.Trim
        If NumericAno.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el año", MsgBoxStyle.Exclamation, "Atención") : TextDias.Focus() : Exit Sub
        Dim ano As Integer = NumericAno.Value
        If TextId.Text.Length > 0 Then
            Dim l As New dLicenciaAnual
            Dim id As Long = CType(TextId.Text.Trim, Long)
            l.ID = id
            l.FUNCIONARIO = idfuncionario
            l.DIAS = dias
            l.ANO = ano
            If (l.modificar(Usuario)) Then
                MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim l As New dLicenciaAnual
            l.FUNCIONARIO = idfuncionario
            l.DIAS = dias
            l.ANO = ano
            If (l.guardar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        cargarLista()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Funcionario" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim l As New dLicenciaAnual
            id = row.Cells("Id").Value
            l.ID = id
            l = l.buscar
            If Not l Is Nothing Then
                TextId.Text = l.ID
                Dim u As dUsuario
                ComboFuncionarios.SelectedItem = Nothing
                For Each u In ComboFuncionarios.Items
                    If u.ID = l.FUNCIONARIO Then
                        ComboFuncionarios.SelectedItem = u
                        Exit For
                    End If
                Next
                TextDias.Text = l.DIAS
                NumericAno.Value = l.ANO
            End If
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Dias" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim l As New dLicenciaAnual
            id = row.Cells("Id").Value
            l.ID = id
            l = l.buscar
            If Not l Is Nothing Then
                TextId.Text = l.ID
                Dim u As dUsuario
                ComboFuncionarios.SelectedItem = Nothing
                For Each u In ComboFuncionarios.Items
                    If u.ID = l.FUNCIONARIO Then
                        ComboFuncionarios.SelectedItem = u
                        Exit For
                    End If
                Next
                TextDias.Text = l.DIAS
                NumericAno.Value = l.ANO
            End If
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Ano" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim l As New dLicenciaAnual
            id = row.Cells("Id").Value
            l.ID = id
            l = l.buscar
            If Not l Is Nothing Then
                TextId.Text = l.ID
                Dim u As dUsuario
                ComboFuncionarios.SelectedItem = Nothing
                For Each u In ComboFuncionarios.Items
                    If u.ID = l.FUNCIONARIO Then
                        ComboFuncionarios.SelectedItem = u
                        Exit For
                    End If
                Next
                TextDias.Text = l.DIAS
                NumericAno.Value = l.ANO
            End If
        End If
    End Sub

    Private Sub ButtonNueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNueva.Click
        limpiar()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        eliminar()
    End Sub
    Private Sub eliminar()
        If TextId.Text.Length > 0 Then
            Dim l As New dLicenciaAnual
            Dim id As Long = TextId.Text.Trim
            l.ID = id
            If (l.eliminar(Usuario)) Then
                MsgBox("Registro eliminado", MsgBoxStyle.Information, "Atención")
                cargarLista()
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub
End Class