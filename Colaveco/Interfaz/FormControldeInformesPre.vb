Public Class FormControldeInformesPre
#Region "Constructores"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        limpiar()
    End Sub

#End Region
    Private Sub limpiar()
        DateDesde.Value = Now
        DateHasta.Value = Now
        RadioFQ.Checked = True
        RadioMicro.Checked = False
        RadioSuelos.Checked = False
        RadioNutricion.Checked = False
        TextTotal.Text = ""
        DataGridView1.Rows.Clear()
        DataGridView2.Rows.Clear()
    End Sub
    Private Sub contarcontroles()
        Dim cifq As New dControlInformesFQ
        Dim cimicro As New dControlInformesMicro
        Dim cinut As New dControlInformesNutricion
        Dim cisue As New dControlInformesSuelos
        Dim listafq As New ArrayList
        Dim listamicro As New ArrayList
        Dim listanut As New ArrayList
        Dim listasue As New ArrayList
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        listafq = cifq.listarxfecha(fecdesde, fechasta)
        listamicro = cimicro.listarxfecha(fecdesde, fechasta)
        listanut = cinut.listarxfecha(fecdesde, fechasta)
        listasue = cisue.listarxfecha(fecdesde, fechasta)
        DataGridView1.Rows.Clear()
        Dim fqcal As Integer = 0
        Dim fqcl As Integer = 0
        Dim microcal As Integer = 0
        Dim microagua As Integer = 0
        Dim microsp As Integer = 0
        Dim nut As Integer = 0
        Dim sue As Integer = 0
        Dim cantidad As Integer = 0
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        DataGridView1.Rows.Add(1)
        If Not listafq Is Nothing Then
            If listafq.Count > 0 Then
                For Each cifq In listafq
                    If cifq.TIPO = 1 Then
                        fqcl = fqcl + 1
                        cantidad = cantidad + 1
                    ElseIf cifq.TIPO = 10 Then
                        fqcal = fqcal + 1
                        cantidad = cantidad + 1
                    End If
                Next
            End If
        End If

        If Not listamicro Is Nothing Then
            If listamicro.Count > 0 Then
                For Each cimicro In listamicro
                    If cimicro.TIPO = 10 Then
                        microcal = microcal + 1
                        cantidad = cantidad + 1
                    ElseIf cimicro.TIPO = 3 Then
                        microagua = microagua + 1
                        cantidad = cantidad + 1
                    ElseIf cimicro.TIPO = 7 Then
                        microsp = microsp + 1
                        cantidad = cantidad + 1
                    End If
                Next
            End If
        End If

        If Not listanut Is Nothing Then
            If listanut.Count > 0 Then
                For Each cinut In listanut
                    nut = nut + 1
                    cantidad = cantidad + 1
                Next
            End If
        End If

        If Not listasue Is Nothing Then
            If listasue.Count > 0 Then
                For Each cisue In listasue
                    sue = sue + 1
                    cantidad = cantidad + 1
                Next
            End If
        End If

        DataGridView1(columna, fila).Value = fqcal
        columna = columna + 1
        DataGridView1(columna, fila).Value = fqcl
        columna = columna + 1
        DataGridView1(columna, fila).Value = microcal
        columna = columna + 1
        DataGridView1(columna, fila).Value = microagua
        columna = columna + 1
        DataGridView1(columna, fila).Value = microsp
        columna = columna + 1
        DataGridView1(columna, fila).Value = nut
        columna = columna + 1
        DataGridView1(columna, fila).Value = sue
        columna = columna + 1
        TextTotal.Text = cantidad
    End Sub

    Private Sub ButtonListar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonListar.Click
        contarcontroles()
        If RadioFQ.Checked = True Then
            listarfq()
        ElseIf RadioMicro.Checked = True Then
            listarmicro()
        ElseIf RadioSuelos.Checked = True Then
            listarsuelos()
        ElseIf RadioNutricion.Checked = True Then
            listarnutricion()
        End If
    End Sub
    Private Sub listarfq()

    End Sub
    Private Sub listarmicro()

    End Sub
    Private Sub listarsuelos()

    End Sub
    Private Sub listarnutricion()

    End Sub
End Class