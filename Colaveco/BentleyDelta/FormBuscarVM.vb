Public Class FormBuscarVM
    Private _vm As dVMediosBD
    Public Property VM() As dVMediosBD
        Get
            Return _vm
        End Get
        Set(ByVal value As dVMediosBD)
            _vm = value
        End Set
    End Property
#Region "Constructores"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        listar()


    End Sub
#End Region

    Private Sub listar()
        Dim vm As New dVMediosBD
        Dim lista As New ArrayList
        lista = vm.listarultimos
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            DataGridView1.Rows.Add(lista.Count)
        End If
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each vm In lista
                    DataGridView1(columna, fila).Value = vm.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = vm.FECHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = vm.GRASA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = vm.GRASA2
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = vm.PROTEINA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = vm.PROTEINA2
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = vm.LACTOSA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = vm.LACTOSA2
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = vm.SOLTOTALES
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = vm.SOLTOTALES2
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = vm.CELULAS
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = vm.CELULAS2
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = vm.CRIOSCOPIA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = vm.CRIOSCOPIA2
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = vm.UREA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = vm.UREA2
                    columna = 0
                    fila = fila + 1
                Next
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Seleccionar" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim vm_ As New dVMediosBD
            id = row.Cells("Id").Value
            vm_.ID = id
            vm_ = vm_.buscar
            If Not vm_ Is Nothing Then
                VM = vm_
                Me.Close()
            End If
        End If
    End Sub
End Class