Public Class FormInformeFrascosRotos

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim infr As New dInformeFrascosRotos
        Dim fr As New dFrascosRotos
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")

        Dim lista As ArrayList
        lista = fr.listarfrascospormes(fecdesde, fechasta)

        DataGridView1.Rows.Clear()
        'ListPendientes.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim año As String
                Dim mes As String
                Dim total As Long
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each infr In lista
                    año = infr.AÑO
                    mes = infr.MES
                    total = infr.TOTAL
                    DataGridView1(columna, fila).Value = año
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = mes
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = total
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

            End If
        End If

    End Sub
End Class