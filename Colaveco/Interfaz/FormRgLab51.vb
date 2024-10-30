Public Class FormRgLab51
    Private equipo As String = ""
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        cargarlista()
        limpiar()
    End Sub
    Private Sub cargarlista()
        Dim rg51 As New dRgLab51
        Dim lista As New ArrayList
        lista = rg51.listarfechas
        DataGridFechas.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridFechas.Rows.Add(lista.Count)
                For Each rg51 In lista
                    DataGridFechas(columna, fila).Value = rg51.FECHA
                    fila = fila + 1
                Next
            End If
        End If
    End Sub
    Private Sub limpiar()
        cargarlista()
        RadioBentley.Checked = True
    End Sub

    Private Sub DataGridFechas_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridFechas.CellContentClick
        If DataGridFechas.Columns(e.ColumnIndex).Name = "Fecha" Then
            Dim row As DataGridViewRow = DataGridFechas.Rows(e.RowIndex)
            Dim fecha As Date
            fecha = row.Cells("Fecha").Value
            DateFecha.Value = fecha
        End If
    End Sub

    Private Sub ButtonListar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonListar.Click
        If RadioBentley.Checked = True Then
            equipo = "Bentley"
            listar()
        ElseIf RadioB6.Checked = True Then
            equipo = "Bentley600"
            listar()
        ElseIf RadioDelta.Checked = True Then
            equipo = "Delta"
            listar()
        End If
    End Sub
    Private Sub listar()
        Dim rg51 As New dRgLab51_informes
        Dim lista As New ArrayList
        Dim _fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim _fec As String
        _fec = Format(_fecha, "yyyy-MM-dd")
        lista = rg51.listarxfechaxequipo(_fec, equipo)
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each rg51 In lista
                    DataGridView1(columna, fila).Value = rg51.MUESTRA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = rg51.RESULTADO1
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = rg51.RESULTADO2
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = rg51.PROMEDIO
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = rg51.DIFMAX
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = rg51.DIF
                    columna = columna + 1
                    If rg51.RESULTADO = 0 Then
                        DataGridView1(columna, fila).Value = "Correcto"
                        DataGridView1(columna, fila).Style.BackColor = Color.Green
                        DataGridView1(columna, fila).Style.ForeColor = Color.Black
                        columna = 0
                        fila = fila + 1
                    ElseIf rg51.RESULTADO = 1 Then
                        DataGridView1(columna, fila).Value = "Correcto"
                        DataGridView1(columna, fila).Style.BackColor = Color.Yellow
                        DataGridView1(columna, fila).Style.ForeColor = Color.Black
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = "Incorrecto"
                        DataGridView1(columna, fila).Style.BackColor = Color.Red
                        DataGridView1(columna, fila).Style.ForeColor = Color.White
                        columna = 0
                        fila = fila + 1
                    End If
                Next
            End If
        End If
    End Sub
End Class