Public Class FormAsociar
    Private _Cotizacion As dCotizacion
    Public Property Cotizacion() As dCotizacion
        Get
            Return _Cotizacion
        End Get
        Set(ByVal value As dCotizacion)
            _Cotizacion = value
        End Set
    End Property
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
        cargarlista()

        'limpiar()
    End Sub

#End Region
    Private Sub cargarlista()
        Dim c As New dCotizacion
        Dim lista As New ArrayList
        lista = c.listarsinasociar
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each c In lista
                    DataGridView1(columna, fila).Value = c.ID
                    columna = columna + 1
                    Dim p As New dProveedores
                    p.ID = c.PROVEEDOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridView1(columna, fila).Value = p.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    DataGridView1(columna, fila).Value = c.FECHA
                    columna = columna + 1
                    Dim usu As New dUsuario
                    usu.ID = c.USUARIOCREADOR
                    usu = usu.buscar
                    If Not usu Is Nothing Then
                        DataGridView1(columna, fila).Value = usu.NOMBRE
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

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Proveedor" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim c As New dCotizacion
            id = row.Cells("Id").Value
            c.ID = id
            c = c.buscar()
            Dim cot As dCotizacion = c
            Cotizacion = cot
            Me.Close()
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Fecha" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim c As New dCotizacion
            id = row.Cells("Id").Value
            c.ID = id
            c = c.buscar()
            Dim cot As dCotizacion = c
            Cotizacion = cot
            Me.Close()
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Solicitante" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim c As New dCotizacion
            id = row.Cells("Id").Value
            c.ID = id
            c = c.buscar()
            Dim cot As dCotizacion = c
            Cotizacion = cot
            Me.Close()
        End If
    End Sub
End Class