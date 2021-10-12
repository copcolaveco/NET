Public Class FormVerValoresIBC
    Dim fechadesde As String
    Dim fechahasta As String
#Region "Constructores"
    Public Sub New(ByVal fecd As String, ByVal fech As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        fechadesde = fecd
        fechahasta = fech
        listar()
    End Sub

#End Region
    Private Sub listar()
        Dim c As New dLecturasIbc
        Dim lista As New ArrayList
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        lista = c.listarporfecha(fechadesde, fechahasta)
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridView1.Rows.Add(lista.Count)
                For Each c In lista
                    DataGridView1(columna, fila).Value = c.FECHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = c.B1
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = c.A1
                    columna = 0
                    fila = fila + 1
                Next
            End If
        End If
    End Sub
End Class