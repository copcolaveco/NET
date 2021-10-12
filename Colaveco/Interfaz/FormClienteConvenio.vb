Public Class FormClienteConvenio
#Region "Atributos"
    Private _usuario As dUsuario
    Private _cli As Long
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
    Public Sub New(ByVal u As dUsuario, ByVal cli As Long)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        _cli = cli
        Dim c As New dCliente
        c.ID = _cli
        c = c.buscar
        If Not c Is Nothing Then
            TextCliente.Text = c.NOMBRE
        End If
        cargarlista()
        cargarlista2()
    End Sub

#End Region
    Private Sub cargarlista()
        Dim c As New dConvenio
        Dim lista As New ArrayList
        lista = c.listar
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each c In lista
                    DataGridView1(columna, fila).Value = c.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = c.NOMBRE
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Private Sub cargarlista2()
        Dim cc As New dClienteConvenio
        Dim lista As New ArrayList
        lista = cc.listarporcliente(_cli)
        DataGridView2.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView2.Rows.Add(lista.Count)
                For Each cc In lista
                    DataGridView2(columna, fila).Value = cc.ID
                    columna = columna + 1
                    Dim c As New dConvenio
                    c.ID = cc.CONVENIO
                    c = c.buscar
                    If Not c Is Nothing Then
                        DataGridView2(columna, fila).Value = c.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView2(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                    
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Agregar" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            id = row.Cells("Id").Value
            Dim c As New dClienteConvenio
            c.CLIENTE = _cli
            c.CONVENIO = id
            c.guardar(Usuario)
            cargarlista2()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView2_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        If DataGridView2.Columns(e.ColumnIndex).Name = "Quitar" Then
            Dim row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
            Dim id As Long = 0
            id = row.Cells("Id2").Value
            Dim c As New dClienteConvenio
            c.ID = id
            c.eliminar(Usuario)
            cargarlista2()
        End If
    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub
End Class