Public Class FormMarcarSolicitudSubida
    Private _usuario As dUsuario
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
        listarpendientes()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u

    End Sub
#End Region
    Private Sub listarpendientes()
        Dim s As New dSolicitudAnalisis
        Dim p As New dProductor
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        lista = s.listarpendientes
        Dim control As Integer = 0
        Dim calidad As Integer = 0
        Dim agua As Integer = 0
        Dim antibiograma As Integer = 0
        Dim pal As Integer = 0
        Dim parasitologia As Integer = 0
        Dim productos As Integer = 0
        Dim serologia As Integer = 0
        Dim patologia As Integer = 0
        Dim ambiental As Integer = 0
        Dim lactometros As Integer = 0
        Dim agro As Integer = 0
        Dim otros As Integer = 0

        For Each t In lista2

            control = t.CONTROL
            calidad = t.CALIDAD
            agua = t.AGUA
            antibiograma = t.ANTIBIOGRAMA
            pal = t.PAL
            parasitologia = t.PARASITOLOGIA
            productos = t.PRODUCTOS
            serologia = t.SEROLOGIA
            patologia = t.PATOLOGIA
            ambiental = t.AMBIENTAL
            lactometros = t.LACTOMETROS
            agro = t.AGRO
            otros = t.OTROS
        Next
        DataGridView1.Rows.Clear()
        'ListPendientes.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each s In lista
                   
                    Dim informe As String = ""
                    If s.IDTIPOINFORME = 1 Then
                        informe = "Control lechero"
                    ElseIf s.IDTIPOINFORME = 10 Then
                        informe = "Calidad de leche"
                    ElseIf s.IDTIPOINFORME = 3 Then
                        informe = "Agua"
                    ElseIf s.IDTIPOINFORME = 4 Then
                        informe = "Antibiograma"
                    ElseIf s.IDTIPOINFORME = 5 Then
                        informe = "PAL"
                    ElseIf s.IDTIPOINFORME = 6 Then
                        informe = "Parasitología"
                    ElseIf s.IDTIPOINFORME = 7 Then
                        informe = "Productos lácteos"
                    ElseIf s.IDTIPOINFORME = 8 Then
                        informe = "Serología"
                    ElseIf s.IDTIPOINFORME = 9 Then
                        informe = "Patología"
                    ElseIf s.IDTIPOINFORME = 11 Then
                        informe = "Ambiental"
                    ElseIf s.IDTIPOINFORME = 12 Then
                        informe = "Lactómetros"
                    ElseIf s.IDTIPOINFORME = 13 Then
                        informe = "Agro-nutrición"
                    ElseIf s.IDTIPOINFORME = 99 Then
                        informe = "Otros servicios"
                    End If
                    
                    p.ID = s.IDPRODUCTOR
                    p = p.buscar

                    'ListPendientes.Items.Add(s.FECHAINGRESO & Chr(9) & diasatraso & Chr(9) & p.NOMBRE & Chr(9) & informe & Chr(9) & s.ID)

                    DataGridView1(columna, fila).Value = s.FECHAINGRESO
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = p.NOMBRE
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = informe
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = s.ID
                    columna = 0
                    fila = fila + 1
                Next
                DataGridView1.Sort(DataGridView1.Columns(3), System.ComponentModel.ListSortDirection.Ascending)
                
            End If
        End If
    End Sub
  

    Private Sub DataGridView1_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        If DataGridView1.Columns(e.ColumnIndex).Name = "Marca" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim s As New dSolicitudAnalisis
            id = row.Cells("Ficha").Value
            s.ID = id
            s.marcar(Usuario)
            listarpendientes()
        End If
    End Sub
End Class