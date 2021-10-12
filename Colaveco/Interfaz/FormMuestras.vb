Public Class FormMuestras
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
        cargarComboInformes()
        cargarLista()
        limpiar()
    End Sub

#End Region
    Public Sub cargarComboInformes()
        Dim ti As New dTipoInforme
        Dim lista As New ArrayList
        lista = ti.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each ti In lista
                    ComboTipoInforme.Items.Add(ti)
                Next
            End If
        End If
    End Sub
    Public Sub cargarLista()
        Dim m As New dMuestras
        Dim lista As New ArrayList
        lista = m.listar
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each m In lista
                    DataGridView1(columna, fila).Value = m.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = m.NOMBRE
                    columna = columna + 1
                    Dim ti As New dTipoInforme
                    ti.ID = m.TIPOINFORME
                    ti = ti.buscar
                    If Not ti Is Nothing Then
                        DataGridView1(columna, fila).Value = ti.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Public Sub limpiar()
        TextId.Text = ""
        TextNombre.Text = ""
        ComboTipoInforme.SelectedItem = Nothing
        ComboTipoInforme.Text = ""
        CheckNoUsar.Checked = False
        CheckAcreditado.Checked = False
        TextNombre.Focus()
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        cargarLista()
        limpiar()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        Dim nombre As String = TextNombre.Text.Trim
        If ComboTipoInforme.Text.Trim.Length = 0 Then MsgBox("Debe ingresar un tipo de informe", MsgBoxStyle.Exclamation, "Atención") : ComboTipoInforme.Focus() : Exit Sub
        Dim idtipoinforme As dTipoInforme = CType(ComboTipoInforme.SelectedItem, dTipoInforme)
        Dim no_usar As Integer = 0
        If CheckNoUsar.Checked = True Then
            no_usar = 1
        Else
            no_usar = 0
        End If
        Dim acreditado As Integer = 0
        If CheckAcreditado.Checked = True Then
            acreditado = 1
        Else
            acreditado = 0
        End If
        If TextId.Text.Trim.Length > 0 Then
            If TextNombre.Text.Trim.Length > 0 Then
                Dim mue As New dMuestras()
                Dim id As Long = TextId.Text.Trim
                mue.ID = id
                mue.NOMBRE = nombre
                mue.TIPOINFORME = idtipoinforme.ID
                mue.NOUSAR = no_usar
                mue.ACREDITADO = acreditado
                If (mue.modificar(Usuario)) Then
                    MsgBox("Muestra modificada", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        Else
            If TextNombre.Text.Trim.Length > 0 Then
                Dim mue As New dMuestras()
                mue.NOMBRE = nombre
                mue.TIPOINFORME = idtipoinforme.ID
                mue.NOUSAR = no_usar
                mue.ACREDITADO = acreditado
                If (mue.guardar(Usuario)) Then
                    MsgBox("Muestra guardada", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        limpiar()
        cargarLista()
    End Sub

    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        If TextId.Text <> "" Then
            Dim m As New dMuestras
            Dim id As Long = CType(TextId.Text, Long)
            m.ID = id
            If (m.eliminar(Usuario)) Then
                MsgBox("Muestra eliminada", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        limpiar()
        cargarLista()
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Muestra" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim m As New dMuestras
            id = row.Cells("Id").Value
            m.ID = id
            m = m.buscar
            If Not m Is Nothing Then
                TextId.Text = m.ID
                TextNombre.Text = m.NOMBRE
                Dim ti As dTipoInforme
                ComboTipoInforme.SelectedItem = Nothing
                For Each ti In ComboTipoInforme.Items
                    If ti.ID = m.TIPOINFORME Then
                        ComboTipoInforme.SelectedItem = ti
                        Exit For
                    End If
                Next
                If m.NOUSAR = 0 Then
                    CheckNoUsar.Checked = False
                Else
                    CheckNoUsar.Checked = True
                End If
                If m.ACREDITADO = 0 Then
                    CheckAcreditado.Checked = False
                Else
                    CheckAcreditado.Checked = True
                End If
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Informe" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim m As New dMuestras
            id = row.Cells("Id").Value
            m.ID = id
            m = m.buscar
            If Not m Is Nothing Then
                TextId.Text = m.ID
                TextNombre.Text = m.NOMBRE
                Dim ti As dTipoInforme
                ComboTipoInforme.SelectedItem = Nothing
                For Each ti In ComboTipoInforme.Items
                    If ti.ID = m.TIPOINFORME Then
                        ComboTipoInforme.SelectedItem = ti
                        Exit For
                    End If
                Next
                If m.NOUSAR = 0 Then
                    CheckNoUsar.Checked = False
                Else
                    CheckNoUsar.Checked = True
                End If
                If m.ACREDITADO = 0 Then
                    CheckAcreditado.Checked = False
                Else
                    CheckAcreditado.Checked = True
                End If
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class