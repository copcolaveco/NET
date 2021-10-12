Public Class FormCompletoUnidad
    Private _usuario As dUsuario
    Private _idnuevoanalisis As Long
    Private _idanal As Integer = 0

    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#Region "Constructores"
    Public Sub New(ByVal id_ As Long, ByVal idanal As Long, ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        '_idnuevoanalisis = idanal
        _idnuevoanalisis = id_
        _idanal = idanal
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        listar()
    End Sub
#End Region
    Private Sub listar()
        Dim n As New dAnalisisUnidad
        Dim lista As New ArrayList
        lista = n.listarxanalisis(_idanal)
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            DataGridView1.Rows.Add(lista.Count)
            For Each n In lista
                DataGridView1(columna, fila).Value = n.ID
                columna = columna + 1
                DataGridView1(columna, fila).Value = n.UNIDAD
                columna = 0
                fila = fila + 1
            Next
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Unidad" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Integer = 0
            id = row.Cells("IdUnidad").Value
            If id > 0 Then
                Dim na As New dNuevoAnalisis
                Dim unidad As Integer = 0
                unidad = id
                na.ID = _idnuevoanalisis
                na.UNIDAD = unidad
                na.actualizar_unidad(Usuario)
                Me.Close()
            End If
        End If
    End Sub
End Class