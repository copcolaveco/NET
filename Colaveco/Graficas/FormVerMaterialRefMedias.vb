Public Class FormVerMaterialRefMedias
    Dim fechadesde As String
    Dim fechahasta As String
    Dim item As String
    Dim equipo As String
#Region "Constructores"
    Public Sub New(ByVal fecd As String, ByVal fech As String, ByVal itemx As String, ByVal equipox As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        fechadesde = fecd
        fechahasta = fech
        item = itemx
        equipo = equipox
        listar()
    End Sub

#End Region
    Private Sub listar()
        Dim mrm As New dMaterialReferenciaMedias
        Dim lista As New ArrayList
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        lista = mrm.listarxitem(fechadesde, fechahasta, item, equipo)
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridView1.Rows.Add(lista.Count)
                For Each mrm In lista
                    DataGridView1(columna, fila).Value = mrm.FECHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = mrm.EQUIPO
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = mrm.ITEM
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = mrm.LECTURA
                    columna = 0
                    fila = fila + 1
                Next
            End If
        End If
    End Sub
End Class