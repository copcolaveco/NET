Public Class FormCambiarVMIBC
    Private _vm As dControlIbc
    Public Property VM() As dControlIbc
        Get
            Return _vm
        End Get
        Set(ByVal value As dControlIbc)
            _vm = value
        End Set
    End Property
#Region "Constructores"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        cargarvaloresmedios()

    End Sub

#End Region
    Private Sub cargarvaloresmedios()
        Dim c As New dControlIbc
        Dim lista As New ArrayList
        lista = c.listarultimosdiez
        DataGridView1.Rows.Clear()
        'ListPendientes.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each c In lista
                    DataGridView1(columna, fila).Value = c.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = c.FECHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = c.BAJO
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = c.ALTO
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Descending)
            End If
        End If

    End Sub

    Private Sub ButtonMostrarTodas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonMostrarTodas.Click
        Dim c As New dControlIbc
        Dim lista As New ArrayList
        lista = c.listar
        DataGridView1.Rows.Clear()
        'ListPendientes.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each c In lista
                    DataGridView1(columna, fila).Value = c.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = c.FECHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = c.BAJO
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = c.ALTO
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Descending)
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Seleccionar" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim c As New dControlIbc
            c.ID = row.Cells("Id").Value
            c = c.buscar
            VM = c
        End If
        Me.Close()
    End Sub
End Class