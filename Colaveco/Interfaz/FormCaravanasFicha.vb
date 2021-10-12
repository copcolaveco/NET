Public Class FormCaravanasFicha
    Private _usuario As dUsuario
    Private idsol As Long
    Private idprod As Long


    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property

#Region "Constructores"
    Public Sub New(ByVal u As dUsuario, ByVal idpro As Long, ByVal solicitud As Long)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        idsol = solicitud
        idprod = idpro
        listarfechas()

    End Sub
#End Region
    Private Sub listarfechas()
        Dim c As New dCaravanasRfid
        Dim lista As New ArrayList
        lista = c.listarxproductor(idprod)
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each c In lista
                    DataGridView1(columna, fila).Value = c.FECHA
                    fila = fila + 1
                Next
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Fecha" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim fecha_ As String = ""
            Dim c As New dCaravanasRfid
            fecha_ = row.Cells("Fecha").Value
            c.FECHA = fecha_
            c.asociarficha(idsol)
        End If
        Me.Close()
    End Sub
End Class