Public Class FormInformeFrascosEnviados

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ped As New dPedidos
        Dim inf As New dInformeFrascosxMes
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")

        Dim lista As ArrayList
        lista = ped.listarfrascospormes(fecdesde, fechasta)

        DataGridView1.Rows.Clear()
        'ListPendientes.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim año As String
                Dim mes As String
                Dim rc_compos As Long
                Dim agua As Long
                Dim sangre As Long
                Dim esteriles As Long
                Dim otros As Long
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each inf In lista
                    año = inf.AÑO
                    mes = inf.MES
                    rc_compos = inf.TOTALRC
                    agua = inf.TOTALAGUA
                    sangre = inf.TOTALSANGRE
                    esteriles = inf.TOTALESTERILES
                    otros = inf.TOTALOTROS
                    DataGridView1(columna, fila).Value = año
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = mes
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = rc_compos
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = agua
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = sangre
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = esteriles
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = otros
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

            End If
        End If

    End Sub
End Class