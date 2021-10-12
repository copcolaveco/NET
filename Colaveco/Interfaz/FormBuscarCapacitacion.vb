Public Class FormBuscarCapacitacion
    Private _capacitacion As dCapacitacionCab
    Public Property Capacitacion() As dCapacitacionCab
        Get
            Return _capacitacion
        End Get
        Set(ByVal value As dCapacitacionCab)
            _capacitacion = value
        End Set
    End Property
#Region "Atributos"

#End Region
#Region "Constructores"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ingresarano()
        cargarLista()


    End Sub

#End Region
    Private Sub ingresarano()
        Dim fecha As Date = Now
        Dim year As String = fecha.ToString("yyyy-MM-dd")
        Dim year2 As String = Mid(year, 1, 4)
        ComboAno.Text = year2
    End Sub
   
   
    Public Sub cargarLista()
        Dim c As New dCapacitacionCab
        Dim a As New dAreas
        Dim lista As New ArrayList
        Dim ano As Long = Val(ComboAno.Text)
        lista = c.listarxano(ano)
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            DataGridView1.Rows.Add(lista.Count)
        End If
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    DataGridView1(columna, fila).Value = c.ID
                    columna = columna + 1
                    a.ID = c.AREA
                    a = a.buscar
                    If Not a Is Nothing Then
                        DataGridView1(columna, fila).Value = a.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = "vacío"
                        columna = columna + 1
                    End If
                    DataGridView1(columna, fila).Value = c.CAPACITACION
                    columna = 0
                    fila = fila + 1
                Next
            End If
        End If
    End Sub

    Private Sub ComboAno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboAno.SelectedIndexChanged
        cargarLista()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Area" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim c As New dCapacitacionCab
            Dim a As New dAreas
            Dim t As New dCapacitacionTipo
            id = row.Cells("Id").Value
            c.ID = id
            c = c.buscar()
            Dim cap As dCapacitacionCab = c
            Capacitacion = cap
            Me.Close()
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Objetivos" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim c As New dCapacitacionCab
            Dim a As New dAreas
            Dim t As New dCapacitacionTipo
            id = row.Cells("Id").Value
            c.ID = id
            c = c.buscar()
            Dim cap As dCapacitacionCab = c
            Capacitacion = cap
            Me.Close()
        End If
    End Sub
End Class