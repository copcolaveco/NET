Public Class FormReproducibilidad
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
#Region "Constructores"
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        calcularano()
        listar()
        graficar()
    End Sub
#End Region
    Private Sub calcularano()
        Dim hoy As Date = Now
        Dim ano As Integer = 0
        ano = hoy.Year
        _anio = hoy.Year
        NumericAno.Value = ano
    End Sub
    Private Sub listar()
        Dim rglab58 As New dRgLab58_informes
        Dim lista As New ArrayList
        lista = rglab58.listarxano(_anio)
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                For Each rglab58 In lista
                    DataGridView1(columna, fila).Value = rglab58.FECHA
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(2), System.ComponentModel.ListSortDirection.Descending)

            End If
        End If
    End Sub
    Private Sub graficar()
        Chart1.Titles.Clear()

        Dim rglab58 As New dRgLab58_informes
        Dim lista As New ArrayList

        lista = rglab58.listarxfecha2(_anio)

        Chart1.Series(0).Points.Clear()




        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each rglab58 In lista

                    Chart1.Series(0).Points.AddXY(rglab58.FECHA, rglab58.RESULTADO)

                Next
            End If
        End If
    End Sub
End Class