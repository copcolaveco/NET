Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Public Class FormEstadisticaSuelos
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

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
       
    End Sub
#End Region

    Private Sub ButtonListar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonListar.Click
        listar()
    End Sub
    Private Sub listar()
        Dim s As New dSuelos
        Dim sumafosfbray As Double = 0
        Dim sumafosfcitrico As Double = 0
        Dim sumanitratos As Double = 0
        Dim sumaphagua As Double = 0
        Dim sumaphkci As Double = 0
        Dim sumapotasioint As Double = 0
        Dim sumasulfatos As Double = 0
        Dim sumanitrogenoveg As Double = 0
        Dim sumacarbonoorg As Double = 0
        Dim sumamateriaorg As Double = 0
        Dim sumapmn As Double = 0
        Dim sumacalcio As Double = 0
        Dim sumamagnesio As Double = 0
        Dim sumasodio As Double = 0
        Dim sumaacideztit As Double = 0
        Dim sumacic As Double = 0
        Dim sumasb As Double = 0
        Dim cuentafosfbray As Integer = 0
        Dim cuentafosfcitrico As Integer = 0
        Dim cuentanitratos As Integer = 0
        Dim cuentaphagua As Integer = 0
        Dim cuentaphkci As Integer = 0
        Dim cuentapotasioint As Integer = 0
        Dim cuentasulfatos As Integer = 0
        Dim cuentanitrogenoveg As Integer = 0
        Dim cuentacarbonoorg As Integer = 0
        Dim cuentamateriaorg As Integer = 0
        Dim cuentapmn As Integer = 0
        Dim cuentacalcio As Integer = 0
        Dim cuentamagnesio As Integer = 0
        Dim cuentasodio As Integer = 0
        Dim cuentaacideztit As Integer = 0
        Dim cuentacic As Integer = 0
        Dim cuentasb As Integer = 0
        Dim productofosfbray As Double = 1
        Dim productofosfcitrico As Double = 1
        Dim productonitratos As Double = 1
        Dim productophagua As Double = 1
        Dim productophkci As Double = 1
        Dim productopotasioint As Double = 1
        Dim productosulfatos As Double = 1
        Dim productonitrogenoveg As Double = 1
        Dim productocarbonoorg As Double = 1
        Dim productomateriaorg As Double = 1
        Dim productopmn As Double = 1
        Dim productocalcio As Double = 1
        Dim productomagnesio As Double = 1
        Dim productosodio As Double = 1
        Dim productoacideztit As Double = 1
        Dim productocic As Double = 1
        Dim productosb As Double = 1
        Dim mediafosfbray As Double = 0
        Dim mediafosfcitrico As Double = 0
        Dim medianitratos As Double = 0
        Dim mediaphagua As Double = 0
        Dim mediaphkci As Double = 0
        Dim mediapotasioint As Double = 0
        Dim mediasulfatos As Double = 0
        Dim medianitrogenoveg As Double = 0
        Dim mediacarbonoorg As Double = 0
        Dim mediamateriaorg As Double = 0
        Dim mediapmn As Double = 0
        Dim mediacalcio As Double = 0
        Dim mediamagnesio As Double = 0
        Dim mediasodio As Double = 0
        Dim mediaacideztit As Double = 0
        Dim mediacic As Double = 0
        Dim mediasb As Double = 0
        Dim desvfosfbray As Double = 0
        Dim desvfosfcitrico As Double = 0
        Dim desvnitratos As Double = 0
        Dim desvphagua As Double = 0
        Dim desvphkci As Double = 0
        Dim desvpotasioint As Double = 0
        Dim desvsulfatos As Double = 0
        Dim desvcarbonoorg As Double = 0
        Dim desvnitrogenoveg As Double = 0
        Dim desvmateriaorg As Double = 0
        Dim desvpmn As Double = 0
        Dim desvcalcio As Double = 0
        Dim desvmagnesio As Double = 0
        Dim desvsodio As Double = 0
        Dim desvacideztit As Double = 0
        Dim desvcic As Double = 0
        Dim desvsb As Double = 0
        Dim cuadfosfbray As Double = 0
        Dim cuadfosfcitrico As Double = 0
        Dim cuadnitratos As Double = 0
        Dim cuadphagua As Double = 0
        Dim cuadphkci As Double = 0
        Dim cuadpotasioint As Double = 0
        Dim cuadsulfatos As Double = 0
        Dim cuadcarbonoorg As Double = 0
        Dim cuadnitrogenoveg As Double = 0
        Dim cuadmateriaorg As Double = 0
        Dim cuadpmn As Double = 0
        Dim cuadcalcio As Double = 0
        Dim cuadmagnesio As Double = 0
        Dim cuadsodio As Double = 0
        Dim cuadacideztit As Double = 0
        Dim cuadcic As Double = 0
        Dim cuadsb As Double = 0
        Dim sumacuadfosfbray As Double = 0
        Dim sumacuadfosfcitrico As Double = 0
        Dim sumacuadnitratos As Double = 0
        Dim sumacuadphagua As Double = 0
        Dim sumacuadphkci As Double = 0
        Dim sumacuadpotasioint As Double = 0
        Dim sumacuadsulfatos As Double = 0
        Dim sumacuadcarbonoorg As Double = 0
        Dim sumacuadnitrogenoveg As Double = 0
        Dim sumacuadmateriaorg As Double = 0
        Dim sumacuadpmn As Double = 0
        Dim sumacuadcalcio As Double = 0
        Dim sumacuadmagnesio As Double = 0
        Dim sumacuadsodio As Double = 0
        Dim sumacuadacideztit As Double = 0
        Dim sumacuadcic As Double = 0
        Dim sumacuadsb As Double = 0
        Dim restofosfbray As Double = 0
        Dim restofosfcitrico As Double = 0
        Dim restonitratos As Double = 0
        Dim restophagua As Double = 0
        Dim restophkci As Double = 0
        Dim restopotasioint As Double = 0
        Dim restosulfatos As Double = 0
        Dim restonitrogenoveg As Double = 0
        Dim restocarbonoorg As Double = 0
        Dim restomateriaorg As Double = 0
        Dim restopmn As Double = 0
        Dim restocalcio As Double = 0
        Dim restomagnesio As Double = 0
        Dim restosodio As Double = 0
        Dim restoacideztit As Double = 0
        Dim restocic As Double = 0
        Dim restosb As Double = 0
        Dim desvestfosfbray As Double = 0
        Dim desvestfosfcitrico As Double = 0
        Dim desvestnitratos As Double = 0
        Dim desvestphagua As Double = 0
        Dim desvestphkci As Double = 0
        Dim desvestpotasioint As Double = 0
        Dim desvestsulfatos As Double = 0
        Dim desvestnitrogenoveg As Double = 0
        Dim desvestcarbonoorg As Double = 0
        Dim desvestmateriaorg As Double = 0
        Dim desvestpmn As Double = 0
        Dim desvestcalcio As Double = 0
        Dim desvestmagnesio As Double = 0
        Dim desvestsodio As Double = 0
        Dim desvestacideztit As Double = 0
        Dim desvestcic As Double = 0
        Dim desvestsb As Double = 0
        Dim medgeomfosfbray As Double = 0
        Dim medgeomfosfcitrico As Double = 0
        Dim medgeomnitratos As Double = 0
        Dim medgeomphagua As Double = 0
        Dim medgeomphkci As Double = 0
        Dim medgeompotasioint As Double = 0
        Dim medgeomsulfatos As Double = 0
        Dim medgeomnitrogenoveg As Double = 0
        Dim medgeomcarbonoorg As Double = 0
        Dim medgeommateriaorg As Double = 0
        Dim medgeompmn As Double = 0
        Dim medgeomcalcio As Double = 0
        Dim medgeommagnesio As Double = 0
        Dim medgeomsodio As Double = 0
        Dim medgeomacideztit As Double = 0
        Dim medgeomcic As Double = 0
        Dim medgeomsb As Double = 0

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim lista As New ArrayList
        lista = s.listarporfecha(fecdesde, fechasta)
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                Dim contador As Integer = lista.Count
                contador = contador + 6
                DataGridView1.Rows.Add(contador)
                For Each s In lista
                    DataGridView1(columna, fila).Value = s.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = s.FICHA
                    columna = columna + 1
                    If s.FOSFOROBRAY <> -1 Then
                        DataGridView1(columna, fila).Value = s.FOSFOROBRAY
                        columna = columna + 1
                        sumafosfbray = sumafosfbray + s.FOSFOROBRAY
                        cuentafosfbray = cuentafosfbray + 1
                        productofosfbray = productofosfbray * s.FOSFOROBRAY
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If s.FOSFOROCITRICO <> -1 Then
                        DataGridView1(columna, fila).Value = s.FOSFOROCITRICO
                        columna = columna + 1
                        sumafosfcitrico = sumafosfcitrico + s.FOSFOROCITRICO
                        cuentafosfcitrico = cuentafosfcitrico + 1
                        productofosfcitrico = productofosfcitrico * s.FOSFOROCITRICO
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If s.NITRATOS <> -1 Then
                        DataGridView1(columna, fila).Value = s.NITRATOS
                        columna = columna + 1
                        sumanitratos = sumanitratos + s.NITRATOS
                        cuentanitratos = cuentanitratos + 1
                        productonitratos = productonitratos * s.NITRATOS
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If s.PHAGUA <> -1 Then
                        DataGridView1(columna, fila).Value = s.PHAGUA
                        columna = columna + 1
                        sumaphagua = sumaphagua + s.PHAGUA
                        cuentaphagua = cuentaphagua + 1
                        productophagua = productophagua * s.PHAGUA
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If s.PHKCI <> -1 Then
                        DataGridView1(columna, fila).Value = s.PHKCI
                        columna = columna + 1
                        sumaphkci = sumaphkci + s.PHKCI
                        cuentaphkci = cuentaphkci + 1
                        productophkci = productophkci * s.PHKCI
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If s.POTASIOINT <> -1 Then
                        DataGridView1(columna, fila).Value = s.POTASIOINT
                        columna = columna + 1
                        sumapotasioint = sumapotasioint + s.POTASIOINT
                        cuentapotasioint = cuentapotasioint + 1
                        productopotasioint = productopotasioint * s.POTASIOINT
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If s.SULFATOS <> -1 Then
                        DataGridView1(columna, fila).Value = s.SULFATOS
                        columna = columna + 1
                        sumasulfatos = sumasulfatos + s.SULFATOS
                        cuentasulfatos = cuentasulfatos + 1
                        productosulfatos = productosulfatos * s.SULFATOS
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If s.NITROGENOVEGETAL <> -1 Then
                        DataGridView1(columna, fila).Value = s.NITROGENOVEGETAL
                        columna = columna + 1
                        sumanitrogenoveg = sumanitrogenoveg + s.NITROGENOVEGETAL
                        cuentanitrogenoveg = cuentanitrogenoveg + 1
                        productonitrogenoveg = productonitrogenoveg * s.NITROGENOVEGETAL
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If s.CARBONOORGANICO <> -1 Then
                        DataGridView1(columna, fila).Value = s.CARBONOORGANICO
                        columna = columna + 1
                        sumacarbonoorg = sumacarbonoorg + s.CARBONOORGANICO
                        cuentacarbonoorg = cuentacarbonoorg + 1
                        productocarbonoorg = productocarbonoorg * s.CARBONOORGANICO
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If s.MATERIAORGANICA <> -1 Then
                        DataGridView1(columna, fila).Value = s.MATERIAORGANICA
                        columna = columna + 1
                        sumamateriaorg = sumamateriaorg + s.MATERIAORGANICA
                        cuentamateriaorg = cuentamateriaorg + 1
                        productomateriaorg = productomateriaorg * s.MATERIAORGANICA
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If s.PMN <> -1 Then
                        DataGridView1(columna, fila).Value = s.PMN
                        columna = columna + 1
                        sumapmn = sumapmn + s.PMN
                        cuentapmn = cuentapmn + 1
                        productopmn = productopmn * s.PMN
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If s.CALCIO <> -1 And s.CALCIO <> 0 Then
                        DataGridView1(columna, fila).Value = s.CALCIO
                        columna = columna + 1
                        sumacalcio = sumacalcio + s.CALCIO
                        cuentacalcio = cuentacalcio + 1
                        productocalcio = productocalcio * s.CALCIO
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If s.MAGNESIO <> -1 And s.MAGNESIO <> 0 Then
                        DataGridView1(columna, fila).Value = s.MAGNESIO
                        columna = columna + 1
                        sumamagnesio = sumamagnesio + s.MAGNESIO
                        cuentamagnesio = cuentamagnesio + 1
                        productomagnesio = productomagnesio * s.MAGNESIO
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If s.SODIO <> -1 And s.SODIO <> 0 Then
                        DataGridView1(columna, fila).Value = s.SODIO
                        columna = columna + 1
                        sumasodio = sumasodio + s.SODIO
                        cuentasodio = cuentasodio + 1
                        productosodio = productosodio * s.SODIO
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If s.ACIDEZTITULABLE <> -1 And s.ACIDEZTITULABLE <> 0 Then
                        DataGridView1(columna, fila).Value = s.ACIDEZTITULABLE
                        columna = columna + 1
                        sumaacideztit = sumaacideztit + s.ACIDEZTITULABLE
                        cuentaacideztit = cuentaacideztit + 1
                        productoacideztit = productoacideztit * s.ACIDEZTITULABLE
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If s.CIC <> -1 And s.CIC <> 0 Then
                        DataGridView1(columna, fila).Value = s.CIC
                        columna = columna + 1
                        sumacic = sumacic + s.CIC
                        cuentacic = cuentacic + 1
                        productocic = productocic * s.CIC
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If s.SB <> -1 And s.SB <> 0 Then
                        DataGridView1(columna, fila).Value = s.SB
                        columna = 0
                        sumasb = sumasb + s.SB
                        cuentasb = cuentasb + 1
                        productosb = productosb * s.SB
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = 0
                        fila = fila + 1
                    End If
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirectios.Ascending)
                If sumafosfbray <> 0 And cuentafosfbray <> 0 Then
                    mediafosfbray = sumafosfbray / cuentafosfbray
                End If
                If sumafosfcitrico <> 0 And cuentafosfcitrico <> 0 Then
                    mediafosfcitrico = sumafosfcitrico / cuentafosfcitrico
                End If
                If sumanitratos <> 0 And cuentanitratos <> 0 Then
                    medianitratos = sumanitratos / cuentanitratos
                End If
                If sumaphagua <> 0 And cuentaphagua <> 0 Then
                    mediaphagua = sumaphagua / cuentaphagua
                End If
                If sumaphkci <> 0 And cuentaphkci <> 0 Then
                    mediaphkci = sumaphkci / cuentaphkci
                End If
                If sumapotasioint <> 0 And cuentapotasioint <> 0 Then
                    mediapotasioint = sumapotasioint / cuentapotasioint
                End If
                If sumasulfatos <> 0 And cuentasulfatos <> 0 Then
                    mediasulfatos = sumasulfatos / cuentasulfatos
                End If
                If sumanitrogenoveg <> 0 And cuentanitrogenoveg <> 0 Then
                    medianitrogenoveg = sumanitrogenoveg / cuentanitrogenoveg
                End If
                If sumacarbonoorg <> 0 And cuentacarbonoorg <> 0 Then
                    mediacarbonoorg = sumacarbonoorg / cuentacarbonoorg
                End If
                If sumamateriaorg <> 0 And cuentamateriaorg <> 0 Then
                    mediamateriaorg = sumamateriaorg / cuentamateriaorg
                End If
                If sumapmn <> 0 And cuentapmn <> 0 Then
                    mediapmn = sumapmn / cuentapmn
                End If
                If sumacalcio <> 0 And cuentacalcio <> 0 Then
                    mediacalcio = sumacalcio / cuentacalcio
                End If
                If sumamagnesio <> 0 And cuentamagnesio <> 0 Then
                    mediamagnesio = sumamagnesio / cuentamagnesio
                End If
                If sumasodio <> 0 And cuentasodio <> 0 Then
                    mediasodio = sumasodio / cuentasodio
                End If
                If sumaacideztit <> 0 And cuentaacideztit <> 0 Then
                    mediaacideztit = sumaacideztit / cuentaacideztit
                End If
                If sumacic <> 0 And cuentacic <> 0 Then
                    mediacic = sumacic / cuentacic
                End If
                If sumasb <> 0 And cuentasb <> 0 Then
                    mediasb = sumasb / cuentasb
                End If
                For Each s In lista
                    If s.FOSFOROBRAY <> -1 Then
                        desvfosfbray = s.FOSFOROBRAY - mediafosfbray
                        cuadfosfbray = desvfosfbray * desvfosfbray
                        sumacuadfosfbray = sumacuadfosfbray + cuadfosfbray
                    End If
                    If s.FOSFOROCITRICO <> -1 Then
                        desvfosfcitrico = s.FOSFOROCITRICO - mediafosfcitrico
                        cuadfosfcitrico = desvfosfcitrico * desvfosfcitrico
                        sumacuadfosfcitrico = sumacuadfosfcitrico + cuadfosfcitrico
                    End If
                    If s.NITRATOS <> -1 Then
                        desvnitratos = s.NITRATOS - medianitratos
                        cuadnitratos = desvnitratos * desvnitratos
                        sumacuadnitratos = sumacuadnitratos + cuadnitratos
                    End If
                    If s.PHAGUA <> -1 Then
                        desvphagua = s.PHAGUA - mediaphagua
                        cuadphagua = desvphagua * desvphagua
                        sumacuadphagua = sumacuadphagua + cuadphagua
                    End If
                    If s.PHKCI <> -1 Then
                        desvphkci = s.PHKCI - mediaphkci
                        cuadphkci = desvphkci * desvphkci
                        sumacuadphkci = sumacuadphkci + cuadphkci
                    End If
                    If s.POTASIOINT <> -1 Then
                        desvpotasioint = s.POTASIOINT - mediapotasioint
                        cuadpotasioint = desvpotasioint * desvpotasioint
                        sumacuadpotasioint = sumacuadpotasioint + cuadpotasioint
                    End If
                    If s.SULFATOS <> -1 Then
                        desvsulfatos = s.SULFATOS - mediasulfatos
                        cuadsulfatos = desvsulfatos * desvsulfatos
                        sumacuadsulfatos = sumacuadsulfatos + cuadsulfatos
                    End If
                    If s.NITROGENOVEGETAL <> -1 Then
                        desvnitrogenoveg = s.NITROGENOVEGETAL - medianitrogenoveg
                        cuadnitrogenoveg = desvnitrogenoveg * desvnitrogenoveg
                        sumacuadnitrogenoveg = sumacuadnitrogenoveg + cuadnitrogenoveg
                    End If
                    If s.CARBONOORGANICO <> -1 Then
                        desvcarbonoorg = s.CARBONOORGANICO - mediacarbonoorg
                        cuadcarbonoorg = desvcarbonoorg * desvcarbonoorg
                        sumacuadcarbonoorg = sumacuadcarbonoorg + cuadcarbonoorg
                    End If
                    If s.MATERIAORGANICA <> -1 Then
                        desvmateriaorg = s.MATERIAORGANICA - mediamateriaorg
                        cuadmateriaorg = desvmateriaorg * desvmateriaorg
                        sumacuadmateriaorg = sumacuadmateriaorg + cuadmateriaorg
                    End If
                    If s.PMN <> -1 Then
                        desvpmn = s.PMN - mediapmn
                        cuadpmn = desvpmn * desvpmn
                        sumacuadpmn = sumacuadpmn + cuadpmn
                    End If
                    If s.CALCIO <> -1 Then
                        desvcalcio = s.CALCIO - mediacalcio
                        cuadcalcio = desvcalcio * desvcalcio
                        sumacuadcalcio = sumacuadcalcio + cuadcalcio
                    End If
                    If s.MAGNESIO <> -1 Then
                        desvmagnesio = s.MAGNESIO - mediamagnesio
                        cuadmagnesio = desvmagnesio * desvmagnesio
                        sumacuadmagnesio = sumacuadmagnesio + cuadmagnesio
                    End If
                    If s.SODIO <> -1 Then
                        desvsodio = s.SODIO - mediasodio
                        cuadsodio = desvsodio * desvsodio
                        sumacuadsodio = sumacuadsodio + cuadsodio
                    End If
                    If s.ACIDEZTITULABLE <> -1 Then
                        desvacideztit = s.ACIDEZTITULABLE - mediaacideztit
                        cuadacideztit = desvacideztit * desvacideztit
                        sumacuadacideztit = sumacuadacideztit + cuadacideztit
                    End If
                    If s.CIC <> -1 Then
                        desvcic = s.CIC - mediacic
                        cuadcic = desvcic * desvcic
                        sumacuadcic = sumacuadcic + cuadcic
                    End If
                    If s.SB <> -1 Then
                        desvsb = s.SB - mediasb
                        cuadsb = desvsb * desvsb
                        sumacuadsb = sumacuadsb + cuadsb
                    End If
                Next
                If sumacuadfosfbray > 0 Then
                    restofosfbray = sumacuadfosfbray / (cuentafosfbray - 1)
                End If
                If sumacuadfosfcitrico > 0 Then
                    restofosfcitrico = sumacuadfosfcitrico / (cuentafosfcitrico - 1)
                End If
                If sumacuadnitratos > 0 Then
                    restonitratos = sumacuadnitratos / (cuentanitratos - 1)
                End If
                If sumacuadphagua > 0 Then
                    restophagua = sumacuadphagua / (cuentaphagua - 1)
                End If
                If sumacuadphkci > 0 Then
                    restophkci = sumacuadphkci / (cuentaphkci - 1)
                End If
                If sumacuadpotasioint > 0 Then
                    restopotasioint = sumacuadpotasioint / (cuentapotasioint - 1)
                End If
                If sumacuadsulfatos > 0 Then
                    restosulfatos = sumacuadsulfatos / (cuentasulfatos - 1)
                End If
                If sumacuadnitrogenoveg > 0 Then
                    restonitrogenoveg = sumacuadnitrogenoveg / (cuentanitrogenoveg - 1)
                End If
                If sumacuadcarbonoorg > 0 Then
                    restocarbonoorg = sumacuadcarbonoorg / (cuentacarbonoorg - 1)
                End If
                If sumacuadmateriaorg > 0 Then
                    restomateriaorg = sumacuadmateriaorg / (cuentamateriaorg - 1)
                End If
                If sumacuadpmn > 0 Then
                    restopmn = sumacuadpmn / (cuentapmn - 1)
                End If
                If sumacuadcalcio > 0 Then
                    restocalcio = sumacuadcalcio / (cuentacalcio - 1)
                End If
                If sumacuadmagnesio > 0 Then
                    restomagnesio = sumacuadmagnesio / (cuentamagnesio - 1)
                End If
                If sumacuadsodio > 0 Then
                    restosodio = sumacuadsodio / (cuentasodio - 1)
                End If
                If sumacuadacideztit > 0 Then
                    restoacideztit = sumacuadacideztit / (cuentaacideztit - 1)
                End If
                If sumacuadcic > 0 Then
                    restocic = sumacuadcic / (cuentacic - 1)
                End If
                If sumacuadsb > 0 Then
                    restosb = sumacuadsb / (cuentasb - 1)
                End If
                If restofosfbray > 0 Then
                    desvestfosfbray = Math.Sqrt(restofosfbray)
                End If
                If restofosfcitrico > 0 Then
                    desvestfosfcitrico = Math.Sqrt(restofosfcitrico)
                End If
                If restonitratos > 0 Then
                    desvestnitratos = Math.Sqrt(restonitratos)
                End If
                If restophagua > 0 Then
                    desvestphagua = Math.Sqrt(restophagua)
                End If
                If restophkci > 0 Then
                    desvestphkci = Math.Sqrt(restophkci)
                End If
                If restopotasioint > 0 Then
                    desvestpotasioint = Math.Sqrt(restopotasioint)
                End If
                If restosulfatos > 0 Then
                    desvestsulfatos = Math.Sqrt(restosulfatos)
                End If
                If restonitrogenoveg > 0 Then
                    desvestnitrogenoveg = Math.Sqrt(restonitrogenoveg)
                End If
                If restocarbonoorg > 0 Then
                    desvestcarbonoorg = Math.Sqrt(restocarbonoorg)
                End If
                If restomateriaorg > 0 Then
                    desvestmateriaorg = Math.Sqrt(restomateriaorg)
                End If
                If restopmn > 0 Then
                    desvestpmn = Math.Sqrt(restopmn)
                End If
                If restocalcio > 0 Then
                    desvestcalcio = Math.Sqrt(restocalcio)
                End If
                If restomagnesio > 0 Then
                    desvestmagnesio = Math.Sqrt(restomagnesio)
                End If
                If restosodio > 0 Then
                    desvestsodio = Math.Sqrt(restosodio)
                End If
                If restoacideztit > 0 Then
                    desvestacideztit = Math.Sqrt(restoacideztit)
                End If
                If restocic > 0 Then
                    desvestcic = Math.Sqrt(restocic)
                End If
                If restosb > 0 Then
                    desvestsb = Math.Sqrt(restosb)
                End If
                medgeomfosfbray = productofosfbray ^ (1 / cuentafosfbray)
                medgeomfosfcitrico = productofosfcitrico ^ (1 / cuentafosfcitrico)
                medgeomnitratos = productonitratos ^ (1 / cuentanitratos)
                medgeomphagua = productophagua ^ (1 / cuentaphagua)
                medgeomphkci = productophkci ^ (1 / cuentaphkci)
                medgeompotasioint = productopotasioint ^ (1 / cuentapotasioint)
                medgeomsulfatos = productosulfatos ^ (1 / cuentasulfatos)
                medgeomnitrogenoveg = productonitrogenoveg ^ (1 / cuentanitrogenoveg)
                medgeomcarbonoorg = productocarbonoorg ^ (1 / cuentacarbonoorg)
                medgeommateriaorg = productomateriaorg ^ (1 / cuentamateriaorg)
                medgeompmn = productopmn ^ (1 / cuentapmn)
                medgeomcalcio = productocalcio ^ (1 / cuentacalcio)
                medgeommagnesio = productomagnesio ^ (1 / cuentamagnesio)
                medgeomsodio = productosodio ^ (1 / cuentasodio)
                medgeomacideztit = productoacideztit ^ (1 / cuentaacideztit)
                medgeomcic = productocic ^ (1 / cuentacic)
                medgeomsb = productosb ^ (1 / cuentasb)

                columna = 1
                fila = fila + 1
                DataGridView1(columna, fila).Value = "Promedio"
                columna = columna + 1
                If mediafosfbray <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(mediafosfbray, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediafosfcitrico <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(mediafosfcitrico, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If medianitratos <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(medianitratos, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediaphagua <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(mediaphagua, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediaphkci <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(mediaphkci, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediapotasioint <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(mediapotasioint, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediasulfatos <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(mediasulfatos, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If medianitrogenoveg <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(medianitrogenoveg, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediacarbonoorg <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(mediacarbonoorg, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediamateriaorg <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(mediamateriaorg, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediapmn <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(mediapmn, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediacalcio <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(mediacalcio, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediamagnesio <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(mediamagnesio, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediasodio <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(mediasodio, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediaacideztit <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(mediaacideztit, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediacic <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(mediacic, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediasb <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(mediasb, 2)
                    columna = 1
                    fila = fila + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = 1
                    fila = fila + 1
                End If

                DataGridView1(columna, fila).Value = "Desv. Estándar"
                columna = columna + 1
                If desvestfosfbray <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(desvestfosfbray, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestfosfcitrico <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(desvestfosfcitrico, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestnitratos <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(desvestnitratos, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestphagua <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(desvestphagua, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestphkci <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(desvestphkci, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestpotasioint <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(desvestpotasioint, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestsulfatos <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(desvestsulfatos, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestnitrogenoveg <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(desvestnitrogenoveg, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestcarbonoorg <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(desvestcarbonoorg, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestmateriaorg <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(desvestmateriaorg, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestpmn <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(desvestpmn, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestcalcio <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(desvestcalcio, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestmagnesio <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(desvestmagnesio, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestsodio <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(desvestsodio, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestacideztit <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(desvestacideztit, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestcic <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(desvestcic, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestsb <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(desvestsb, 2)
                    columna = 1
                    fila = fila + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = 1
                    fila = fila + 1
                End If

                DataGridView1(columna, fila).Value = "Media geom."
                columna = columna + 1
                If medgeomfosfbray <> 1 Then
                    DataGridView1(columna, fila).Value = Math.Round(medgeomfosfbray, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomfosfcitrico <> 1 Then
                    DataGridView1(columna, fila).Value = Math.Round(medgeomfosfcitrico, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomnitratos <> 1 Then
                    DataGridView1(columna, fila).Value = Math.Round(medgeomnitratos, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomphagua <> 1 Then
                    DataGridView1(columna, fila).Value = Math.Round(medgeomphagua, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomphkci <> 1 Then
                    DataGridView1(columna, fila).Value = Math.Round(medgeomphkci, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeompotasioint <> 1 Then
                    DataGridView1(columna, fila).Value = Math.Round(medgeompotasioint, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomsulfatos <> 1 Then
                    DataGridView1(columna, fila).Value = Math.Round(medgeomsulfatos, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomnitrogenoveg <> 1 Then
                    DataGridView1(columna, fila).Value = Math.Round(medgeomnitrogenoveg, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomcarbonoorg <> 1 Then
                    DataGridView1(columna, fila).Value = Math.Round(medgeomcarbonoorg, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeommateriaorg <> 1 Then
                    DataGridView1(columna, fila).Value = Math.Round(medgeommateriaorg, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeompmn <> 1 Then
                    DataGridView1(columna, fila).Value = Math.Round(medgeompmn, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomcalcio <> 1 Then
                    DataGridView1(columna, fila).Value = Math.Round(medgeomcalcio, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeommagnesio <> 1 Then
                    DataGridView1(columna, fila).Value = Math.Round(medgeommagnesio, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomsodio <> 1 Then
                    DataGridView1(columna, fila).Value = Math.Round(medgeomsodio, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomacideztit <> 1 Then
                    DataGridView1(columna, fila).Value = Math.Round(medgeomacideztit, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomcic <> 1 Then
                    DataGridView1(columna, fila).Value = Math.Round(medgeomcic, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomsb <> 1 Then
                    DataGridView1(columna, fila).Value = Math.Round(medgeomsb, 2)
                    columna = 0
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = 0
                End If

            End If
        End If
    End Sub

    Private Sub ButtonListarTodas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ButtonExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportar.Click
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        x1hoja.Cells(1, 1).columnwidth = 10
        x1hoja.Cells(1, 2).columnwidth = 10
        x1hoja.Cells(1, 3).columnwidth = 10
        x1hoja.Cells(1, 4).columnwidth = 10
        x1hoja.Cells(1, 5).columnwidth = 10
        x1hoja.Cells(1, 6).columnwidth = 10
        x1hoja.Cells(1, 7).columnwidth = 10
        x1hoja.Cells(1, 8).columnwidth = 10
        x1hoja.Cells(1, 9).columnwidth = 10
        x1hoja.Cells(1, 10).columnwidth = 10
        x1hoja.Cells(1, 11).columnwidth = 10
        x1hoja.Cells(1, 12).columnwidth = 10
        x1hoja.Cells(1, 13).columnwidth = 10
        x1hoja.Cells(1, 14).columnwidth = 10
        x1hoja.Cells(1, 15).columnwidth = 10
        x1hoja.Cells(1, 16).columnwidth = 10
        x1hoja.Cells(1, 17).columnwidth = 10
        x1hoja.Cells(1, 18).columnwidth = 10

        Dim fila As Integer = 1
        Dim columna As Integer = 1


        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")

        x1hoja.Cells(fila, columna).formula = "ESTADÍSTICAS DE SUELOS" & "  -  " & fecdesde & " - " & fechasta
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        fila = fila + 2
        x1hoja.Cells(fila, columna).formula = "Ficha"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Fosf.Bray"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Fosf. Cítrico"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Nitratos"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "pH Agua"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "pH KCI"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Potasio int."
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Sulfatos"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Nitógeno veg.%"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Carbóno org.%"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Materia org.%"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "PMN"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Calcio"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Magnesio"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Sodio"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Acidez tit."
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "CIC"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "% SB"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        fila = fila + 1
        columna = 1

        Dim s As New dSuelos
        Dim sumafosfbray As Double = 0
        Dim sumafosfcitrico As Double = 0
        Dim sumanitratos As Double = 0
        Dim sumaphagua As Double = 0
        Dim sumaphkci As Double = 0
        Dim sumapotasioint As Double = 0
        Dim sumasulfatos As Double = 0
        Dim sumanitrogenoveg As Double = 0
        Dim sumacarbonoorg As Double = 0
        Dim sumamateriaorg As Double = 0
        Dim sumapmn As Double = 0
        Dim sumacalcio As Double = 0
        Dim sumamagnesio As Double = 0
        Dim sumasodio As Double = 0
        Dim sumaacideztit As Double = 0
        Dim sumacic As Double = 0
        Dim sumasb As Double = 0
        Dim cuentafosfbray As Integer = 0
        Dim cuentafosfcitrico As Integer = 0
        Dim cuentanitratos As Integer = 0
        Dim cuentaphagua As Integer = 0
        Dim cuentaphkci As Integer = 0
        Dim cuentapotasioint As Integer = 0
        Dim cuentasulfatos As Integer = 0
        Dim cuentanitrogenoveg As Integer = 0
        Dim cuentacarbonoorg As Integer = 0
        Dim cuentamateriaorg As Integer = 0
        Dim cuentapmn As Integer = 0
        Dim cuentacalcio As Integer = 0
        Dim cuentamagnesio As Integer = 0
        Dim cuentasodio As Integer = 0
        Dim cuentaacideztit As Integer = 0
        Dim cuentacic As Integer = 0
        Dim cuentasb As Integer = 0
        Dim productofosfbray As Double = 1
        Dim productofosfcitrico As Double = 1
        Dim productonitratos As Double = 1
        Dim productophagua As Double = 1
        Dim productophkci As Double = 1
        Dim productopotasioint As Double = 1
        Dim productosulfatos As Double = 1
        Dim productonitrogenoveg As Double = 1
        Dim productocarbonoorg As Double = 1
        Dim productomateriaorg As Double = 1
        Dim productopmn As Double = 1
        Dim productocalcio As Double = 1
        Dim productomagnesio As Double = 1
        Dim productosodio As Double = 1
        Dim productoacideztit As Double = 1
        Dim productocic As Double = 1
        Dim productosb As Double = 1
        Dim mediafosfbray As Double = 0
        Dim mediafosfcitrico As Double = 0
        Dim medianitratos As Double = 0
        Dim mediaphagua As Double = 0
        Dim mediaphkci As Double = 0
        Dim mediapotasioint As Double = 0
        Dim mediasulfatos As Double = 0
        Dim mediacarbonoorg As Double = 0
        Dim medianitrogenoveg As Double = 0
        Dim mediamateriaorg As Double = 0
        Dim mediapmn As Double = 0
        Dim mediacalcio As Double = 0
        Dim mediamagnesio As Double = 0
        Dim mediasodio As Double = 0
        Dim mediaacideztit As Double = 0
        Dim mediacic As Double = 0
        Dim mediasb As Double = 0
        Dim desvfosfbray As Double = 0
        Dim desvfosfcitrico As Double = 0
        Dim desvnitratos As Double = 0
        Dim desvphagua As Double = 0
        Dim desvphkci As Double = 0
        Dim desvpotasioint As Double = 0
        Dim desvsulfatos As Double = 0
        Dim desvcarbonoorg As Double = 0
        Dim desvnitrogenoveg As Double = 0
        Dim desvmateriaorg As Double = 0
        Dim desvpmn As Double = 0
        Dim desvcalcio As Double = 0
        Dim desvmagnesio As Double = 0
        Dim desvsodio As Double = 0
        Dim desvacideztit As Double = 0
        Dim desvcic As Double = 0
        Dim desvsb As Double = 0
        Dim cuadfosfbray As Double = 0
        Dim cuadfosfcitrico As Double = 0
        Dim cuadnitratos As Double = 0
        Dim cuadphagua As Double = 0
        Dim cuadphkci As Double = 0
        Dim cuadpotasioint As Double = 0
        Dim cuadsulfatos As Double = 0
        Dim cuadcarbonoorg As Double = 0
        Dim cuadnitrogenoveg As Double = 0
        Dim cuadmateriaorg As Double = 0
        Dim cuadpmn As Double = 0
        Dim cuadcalcio As Double = 0
        Dim cuadmagnesio As Double = 0
        Dim cuadsodio As Double = 0
        Dim cuadacideztit As Double = 0
        Dim cuadcic As Double = 0
        Dim cuadsb As Double = 0
        Dim sumacuadfosfbray As Double = 0
        Dim sumacuadfosfcitrico As Double = 0
        Dim sumacuadnitratos As Double = 0
        Dim sumacuadphagua As Double = 0
        Dim sumacuadphkci As Double = 0
        Dim sumacuadpotasioint As Double = 0
        Dim sumacuadsulfatos As Double = 0
        Dim sumacuadcarbonoorg As Double = 0
        Dim sumacuadnitrogenoveg As Double = 0
        Dim sumacuadmateriaorg As Double = 0
        Dim sumacuadpmn As Double = 0
        Dim sumacuadcalcio As Double = 0
        Dim sumacuadmagnesio As Double = 0
        Dim sumacuadsodio As Double = 0
        Dim sumacuadacideztit As Double = 0
        Dim sumacuadcic As Double = 0
        Dim sumacuadsb As Double = 0
        Dim restofosfbray As Double = 0
        Dim restofosfcitrico As Double = 0
        Dim restonitratos As Double = 0
        Dim restophagua As Double = 0
        Dim restophkci As Double = 0
        Dim restopotasioint As Double = 0
        Dim restosulfatos As Double = 0
        Dim restonitrogenoveg As Double = 0
        Dim restocarbonoorg As Double = 0
        Dim restomateriaorg As Double = 0
        Dim restopmn As Double = 0
        Dim restocalcio As Double = 0
        Dim restomagnesio As Double = 0
        Dim restosodio As Double = 0
        Dim restoacideztit As Double = 0
        Dim restocic As Double = 0
        Dim restosb As Double = 0
        Dim desvestfosfbray As Double = 0
        Dim desvestfosfcitrico As Double = 0
        Dim desvestnitratos As Double = 0
        Dim desvestphagua As Double = 0
        Dim desvestphkci As Double = 0
        Dim desvestpotasioint As Double = 0
        Dim desvestsulfatos As Double = 0
        Dim desvestnitrogenoveg As Double = 0
        Dim desvestcarbonoorg As Double = 0
        Dim desvestmateriaorg As Double = 0
        Dim desvestpmn As Double = 0
        Dim desvestcalcio As Double = 0
        Dim desvestmagnesio As Double = 0
        Dim desvestsodio As Double = 0
        Dim desvestacideztit As Double = 0
        Dim desvestcic As Double = 0
        Dim desvestsb As Double = 0
        Dim medgeomfosfbray As Double = 0
        Dim medgeomfosfcitrico As Double = 0
        Dim medgeomnitratos As Double = 0
        Dim medgeomphagua As Double = 0
        Dim medgeomphkci As Double = 0
        Dim medgeompotasioint As Double = 0
        Dim medgeomsulfatos As Double = 0
        Dim medgeomnitrogenoveg As Double = 0
        Dim medgeomcarbonoorg As Double = 0
        Dim medgeommateriaorg As Double = 0
        Dim medgeompmn As Double = 0
        Dim medgeomcalcio As Double = 0
        Dim medgeommagnesio As Double = 0
        Dim medgeomsodio As Double = 0
        Dim medgeomacideztit As Double = 0
        Dim medgeomcic As Double = 0
        Dim medgeomsb As Double = 0

        Dim lista As New ArrayList
        lista = s.listarporfecha(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each s In lista
                    x1hoja.Cells(fila, columna).formula = s.FICHA
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                    If s.FOSFOROBRAY <> -1 Then
                        x1hoja.Cells(fila, columna).formula = s.FOSFOROBRAY
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        sumafosfbray = sumafosfbray + s.FOSFOROBRAY
                        cuentafosfbray = cuentafosfbray + 1
                        productofosfbray = productofosfbray * s.FOSFOROBRAY
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If s.FOSFOROCITRICO <> -1 Then
                        x1hoja.Cells(fila, columna).formula = s.FOSFOROCITRICO
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        sumafosfcitrico = sumafosfcitrico + s.FOSFOROCITRICO
                        cuentafosfcitrico = cuentafosfcitrico + 1
                        productofosfcitrico = productofosfcitrico * s.FOSFOROCITRICO
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If s.NITRATOS <> -1 Then
                        x1hoja.Cells(fila, columna).formula = s.NITRATOS
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        sumanitratos = sumanitratos + s.NITRATOS
                        cuentanitratos = cuentanitratos + 1
                        productonitratos = productonitratos * s.NITRATOS
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If s.PHAGUA <> -1 Then
                        x1hoja.Cells(fila, columna).formula = s.PHAGUA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        sumaphagua = sumaphagua + s.PHAGUA
                        cuentaphagua = cuentaphagua + 1
                        productophagua = productophagua * s.PHAGUA
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If s.PHKCI <> -1 Then
                        x1hoja.Cells(fila, columna).formula = s.PHKCI
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        sumaphkci = sumaphkci + s.PHKCI
                        cuentaphkci = cuentaphkci + 1
                        productophkci = productophkci * s.PHKCI
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If s.POTASIOINT <> -1 Then
                        x1hoja.Cells(fila, columna).formula = s.POTASIOINT
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        sumapotasioint = sumapotasioint + s.POTASIOINT
                        cuentapotasioint = cuentapotasioint + 1
                        productopotasioint = productopotasioint * s.POTASIOINT
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If s.SULFATOS <> -1 Then
                        x1hoja.Cells(fila, columna).formula = s.SULFATOS
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        sumasulfatos = sumasulfatos + s.SULFATOS
                        cuentasulfatos = cuentasulfatos + 1
                        productosulfatos = productosulfatos * s.SULFATOS
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If s.NITROGENOVEGETAL <> -1 Then
                        x1hoja.Cells(fila, columna).formula = s.NITROGENOVEGETAL
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        sumanitrogenoveg = sumanitrogenoveg + s.NITROGENOVEGETAL
                        cuentanitrogenoveg = cuentanitrogenoveg + 1
                        productonitrogenoveg = productonitrogenoveg * s.NITROGENOVEGETAL
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If s.CARBONOORGANICO <> -1 Then
                        x1hoja.Cells(fila, columna).formula = s.CARBONOORGANICO
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        sumacarbonoorg = sumacarbonoorg + s.CARBONOORGANICO
                        cuentacarbonoorg = cuentacarbonoorg + 1
                        productocarbonoorg = productocarbonoorg * s.CARBONOORGANICO
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If s.MATERIAORGANICA <> -1 Then
                        x1hoja.Cells(fila, columna).formula = s.MATERIAORGANICA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        sumamateriaorg = sumamateriaorg + s.MATERIAORGANICA
                        cuentamateriaorg = cuentamateriaorg + 1
                        productomateriaorg = productomateriaorg * s.MATERIAORGANICA
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If s.PMN <> -1 Then
                        x1hoja.Cells(fila, columna).formula = s.PMN
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        sumapmn = sumapmn + s.PMN
                        cuentapmn = cuentapmn + 1
                        productopmn = productopmn * s.PMN
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If s.CALCIO <> -1 And s.CALCIO <> 0 Then
                        x1hoja.Cells(fila, columna).formula = s.CALCIO
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        sumacalcio = sumacalcio + s.CALCIO
                        cuentacalcio = cuentacalcio + 1
                        productocalcio = productocalcio * s.CALCIO
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If s.MAGNESIO <> -1 And s.MAGNESIO <> 0 Then
                        x1hoja.Cells(fila, columna).formula = s.MAGNESIO
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        sumamagnesio = sumamagnesio + s.MAGNESIO
                        cuentamagnesio = cuentamagnesio + 1
                        productomagnesio = productomagnesio * s.MAGNESIO
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If s.SODIO <> -1 And s.SODIO <> 0 Then
                        x1hoja.Cells(fila, columna).formula = s.SODIO
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        sumasodio = sumasodio + s.SODIO
                        cuentasodio = cuentasodio + 1
                        productosodio = productosodio * s.SODIO
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If s.ACIDEZTITULABLE <> -1 And s.ACIDEZTITULABLE <> 0 Then
                        x1hoja.Cells(fila, columna).formula = s.ACIDEZTITULABLE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        sumaacideztit = sumaacideztit + s.ACIDEZTITULABLE
                        cuentaacideztit = cuentaacideztit + 1
                        productoacideztit = productoacideztit * s.ACIDEZTITULABLE
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If s.CIC <> -1 And s.CIC <> 0 Then
                        x1hoja.Cells(fila, columna).formula = s.CIC
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        sumacic = sumacic + s.CIC
                        cuentacic = cuentacic + 1
                        productocic = productocic * s.CIC
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If s.SB <> -1 And s.SB <> 0 Then
                        x1hoja.Cells(fila, columna).formula = s.SB
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        sumasb = sumasb + s.SB
                        cuentasb = cuentasb + 1
                        productosb = productosb * s.SB
                        fila = fila + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                    End If
                Next

                If sumafosfbray <> 0 And cuentafosfbray <> 0 Then
                    mediafosfbray = sumafosfbray / cuentafosfbray
                End If
                If sumafosfcitrico <> 0 And cuentafosfcitrico <> 0 Then
                    mediafosfcitrico = sumafosfcitrico / cuentafosfcitrico
                End If
                If sumanitratos <> 0 And cuentanitratos <> 0 Then
                    medianitratos = sumanitratos / cuentanitratos
                End If
                If sumaphagua <> 0 And cuentaphagua <> 0 Then
                    mediaphagua = sumaphagua / cuentaphagua
                End If
                If sumaphkci <> 0 And cuentaphkci <> 0 Then
                    mediaphkci = sumaphkci / cuentaphkci
                End If
                If sumapotasioint <> 0 And cuentapotasioint <> 0 Then
                    mediapotasioint = sumapotasioint / cuentapotasioint
                End If
                If sumasulfatos <> 0 And cuentasulfatos <> 0 Then
                    mediasulfatos = sumasulfatos / cuentasulfatos
                End If
                If sumanitrogenoveg <> 0 And cuentanitrogenoveg <> 0 Then
                    medianitrogenoveg = sumanitrogenoveg / cuentanitrogenoveg
                End If
                If sumacarbonoorg <> 0 And cuentacarbonoorg <> 0 Then
                    mediacarbonoorg = sumacarbonoorg / cuentacarbonoorg
                End If
                If sumamateriaorg <> 0 And cuentamateriaorg <> 0 Then
                    mediamateriaorg = sumamateriaorg / cuentamateriaorg
                End If
                If sumapmn <> 0 And cuentapmn <> 0 Then
                    mediapmn = sumapmn / cuentapmn
                End If
                If sumacalcio <> 0 And cuentacalcio <> 0 Then
                    mediacalcio = sumacalcio / cuentacalcio
                End If
                If sumamagnesio <> 0 And cuentamagnesio <> 0 Then
                    mediamagnesio = sumamagnesio / cuentamagnesio
                End If
                If sumasodio <> 0 And cuentasodio <> 0 Then
                    mediasodio = sumasodio / cuentasodio
                End If
                If sumaacideztit <> 0 And cuentaacideztit <> 0 Then
                    mediaacideztit = sumaacideztit / cuentaacideztit
                End If
                If sumacic <> 0 And cuentacic <> 0 Then
                    mediacic = sumacic / cuentacic
                End If
                If sumasb <> 0 And cuentasb <> 0 Then
                    mediasb = sumasb / cuentasb
                End If
                For Each s In lista
                    If s.FOSFOROBRAY <> -1 Then
                        desvfosfbray = s.FOSFOROBRAY - mediafosfbray
                        cuadfosfbray = desvfosfbray * desvfosfbray
                        sumacuadfosfbray = sumacuadfosfbray + cuadfosfbray
                    End If
                    If s.FOSFOROCITRICO <> -1 Then
                        desvfosfcitrico = s.FOSFOROCITRICO - mediafosfcitrico
                        cuadfosfcitrico = desvfosfcitrico * desvfosfcitrico
                        sumacuadfosfcitrico = sumacuadfosfcitrico + cuadfosfcitrico
                    End If
                    If s.NITRATOS <> -1 Then
                        desvnitratos = s.NITRATOS - medianitratos
                        cuadnitratos = desvnitratos * desvnitratos
                        sumacuadnitratos = sumacuadnitratos + cuadnitratos
                    End If
                    If s.PHAGUA <> -1 Then
                        desvphagua = s.PHAGUA - mediaphagua
                        cuadphagua = desvphagua * desvphagua
                        sumacuadphagua = sumacuadphagua + cuadphagua
                    End If
                    If s.PHKCI <> -1 Then
                        desvphkci = s.PHKCI - mediaphkci
                        cuadphkci = desvphkci * desvphkci
                        sumacuadphkci = sumacuadphkci + cuadphkci
                    End If
                    If s.POTASIOINT <> -1 Then
                        desvpotasioint = s.POTASIOINT - mediapotasioint
                        cuadpotasioint = desvpotasioint * desvpotasioint
                        sumacuadpotasioint = sumacuadpotasioint + cuadpotasioint
                    End If
                    If s.SULFATOS <> -1 Then
                        desvsulfatos = s.SULFATOS - mediasulfatos
                        cuadsulfatos = desvsulfatos * desvsulfatos
                        sumacuadsulfatos = sumacuadsulfatos + cuadsulfatos
                    End If
                    If s.NITROGENOVEGETAL <> -1 Then
                        desvnitrogenoveg = s.NITROGENOVEGETAL - medianitrogenoveg
                        cuadnitrogenoveg = desvnitrogenoveg * desvnitrogenoveg
                        sumacuadnitrogenoveg = sumacuadnitrogenoveg + cuadnitrogenoveg
                    End If
                    If s.CARBONOORGANICO <> -1 Then
                        desvcarbonoorg = s.CARBONOORGANICO - mediacarbonoorg
                        cuadcarbonoorg = desvcarbonoorg * desvcarbonoorg
                        sumacuadcarbonoorg = sumacuadcarbonoorg + cuadcarbonoorg
                    End If
                    If s.MATERIAORGANICA <> -1 Then
                        desvmateriaorg = s.MATERIAORGANICA - mediamateriaorg
                        cuadmateriaorg = desvmateriaorg * desvmateriaorg
                        sumacuadmateriaorg = sumacuadmateriaorg + cuadmateriaorg
                    End If
                    If s.PMN <> -1 Then
                        desvpmn = s.PMN - mediapmn
                        cuadpmn = desvpmn * desvpmn
                        sumacuadpmn = sumacuadpmn + cuadpmn
                    End If
                    If s.CALCIO <> -1 Then
                        desvcalcio = s.CALCIO - mediacalcio
                        cuadcalcio = desvcalcio * desvcalcio
                        sumacuadcalcio = sumacuadcalcio + cuadcalcio
                    End If
                    If s.MAGNESIO <> -1 Then
                        desvmagnesio = s.MAGNESIO - mediamagnesio
                        cuadmagnesio = desvmagnesio * desvmagnesio
                        sumacuadmagnesio = sumacuadmagnesio + cuadmagnesio
                    End If
                    If s.SODIO <> -1 Then
                        desvsodio = s.SODIO - mediasodio
                        cuadsodio = desvsodio * desvsodio
                        sumacuadsodio = sumacuadsodio + cuadsodio
                    End If
                    If s.ACIDEZTITULABLE <> -1 Then
                        desvacideztit = s.ACIDEZTITULABLE - mediaacideztit
                        cuadacideztit = desvacideztit * desvacideztit
                        sumacuadacideztit = sumacuadacideztit + cuadacideztit
                    End If
                    If s.CIC <> -1 Then
                        desvcic = s.CIC - mediacic
                        cuadcic = desvcic * desvcic
                        sumacuadcic = sumacuadcic + cuadcic
                    End If
                    If s.SB <> -1 Then
                        desvsb = s.SB - mediasb
                        cuadsb = desvsb * desvsb
                        sumacuadsb = sumacuadsb + cuadsb
                    End If
                Next
                If sumacuadfosfbray > 0 Then
                    restofosfbray = sumacuadfosfbray / (cuentafosfbray - 1)
                End If
                If sumacuadfosfcitrico > 0 Then
                    restofosfcitrico = sumacuadfosfcitrico / (cuentafosfcitrico - 1)
                End If
                If sumacuadnitratos > 0 Then
                    restonitratos = sumacuadnitratos / (cuentanitratos - 1)
                End If
                If sumacuadphagua > 0 Then
                    restophagua = sumacuadphagua / (cuentaphagua - 1)
                End If
                If sumacuadphkci > 0 Then
                    restophkci = sumacuadphkci / (cuentaphkci - 1)
                End If
                If sumacuadpotasioint > 0 Then
                    restopotasioint = sumacuadpotasioint / (cuentapotasioint - 1)
                End If
                If sumacuadsulfatos > 0 Then
                    restosulfatos = sumacuadsulfatos / (cuentasulfatos - 1)
                End If
                If sumacuadnitrogenoveg > 0 Then
                    restonitrogenoveg = sumacuadnitrogenoveg / (cuentanitrogenoveg - 1)
                End If
                If sumacuadcarbonoorg > 0 Then
                    restocarbonoorg = sumacuadcarbonoorg / (cuentacarbonoorg - 1)
                End If
                If sumacuadmateriaorg > 0 Then
                    restomateriaorg = sumacuadmateriaorg / (cuentamateriaorg - 1)
                End If
                If sumacuadpmn > 0 Then
                    restopmn = sumacuadpmn / (cuentapmn - 1)
                End If
                If sumacuadcalcio > 0 Then
                    restocalcio = sumacuadcalcio / (cuentacalcio - 1)
                End If
                If sumacuadmagnesio > 0 Then
                    restomagnesio = sumacuadmagnesio / (cuentamagnesio - 1)
                End If
                If sumacuadsodio > 0 Then
                    restosodio = sumacuadsodio / (cuentasodio - 1)
                End If
                If sumacuadacideztit > 0 Then
                    restoacideztit = sumacuadacideztit / (cuentaacideztit - 1)
                End If
                If sumacuadcic > 0 Then
                    restocic = sumacuadcic / (cuentacic - 1)
                End If
                If sumacuadsb > 0 Then
                    restosb = sumacuadsb / (cuentasb - 1)
                End If
                If restofosfbray > 0 Then
                    desvestfosfbray = Math.Sqrt(restofosfbray)
                End If
                If restofosfcitrico > 0 Then
                    desvestfosfcitrico = Math.Sqrt(restofosfcitrico)
                End If
                If restonitratos > 0 Then
                    desvestnitratos = Math.Sqrt(restonitratos)
                End If
                If restophagua > 0 Then
                    desvestphagua = Math.Sqrt(restophagua)
                End If
                If restophkci > 0 Then
                    desvestphkci = Math.Sqrt(restophkci)
                End If
                If restopotasioint > 0 Then
                    desvestpotasioint = Math.Sqrt(restopotasioint)
                End If
                If restosulfatos > 0 Then
                    desvestsulfatos = Math.Sqrt(restosulfatos)
                End If
                If restonitrogenoveg > 0 Then
                    desvestnitrogenoveg = Math.Sqrt(restonitrogenoveg)
                End If
                If restocarbonoorg > 0 Then
                    desvestcarbonoorg = Math.Sqrt(restocarbonoorg)
                End If
                If restomateriaorg > 0 Then
                    desvestmateriaorg = Math.Sqrt(restomateriaorg)
                End If
                If restopmn > 0 Then
                    desvestpmn = Math.Sqrt(restopmn)
                End If
                If restocalcio > 0 Then
                    desvestcalcio = Math.Sqrt(restocalcio)
                End If
                If restomagnesio > 0 Then
                    desvestmagnesio = Math.Sqrt(restomagnesio)
                End If
                If restosodio > 0 Then
                    desvestsodio = Math.Sqrt(restosodio)
                End If
                If restoacideztit > 0 Then
                    desvestacideztit = Math.Sqrt(restoacideztit)
                End If
                If restocic > 0 Then
                    desvestcic = Math.Sqrt(restocic)
                End If
                If restosb > 0 Then
                    desvestsb = Math.Sqrt(restosb)
                End If
                medgeomfosfbray = productofosfbray ^ (1 / cuentafosfbray)
                medgeomfosfcitrico = productofosfcitrico ^ (1 / cuentafosfcitrico)
                medgeomnitratos = productonitratos ^ (1 / cuentanitratos)
                medgeomphagua = productophagua ^ (1 / cuentaphagua)
                medgeomphkci = productophkci ^ (1 / cuentaphkci)
                medgeompotasioint = productopotasioint ^ (1 / cuentapotasioint)
                medgeomsulfatos = productosulfatos ^ (1 / cuentasulfatos)
                medgeomnitrogenoveg = productonitrogenoveg ^ (1 / cuentanitrogenoveg)
                medgeomcarbonoorg = productocarbonoorg ^ (1 / cuentacarbonoorg)
                medgeommateriaorg = productomateriaorg ^ (1 / cuentamateriaorg)
                medgeompmn = productopmn ^ (1 / cuentapmn)
                medgeomcalcio = productocalcio ^ (1 / cuentacalcio)
                medgeommagnesio = productomagnesio ^ (1 / cuentamagnesio)
                medgeomsodio = productosodio ^ (1 / cuentasodio)
                medgeomacideztit = productoacideztit ^ (1 / cuentaacideztit)
                medgeomcic = productocic ^ (1 / cuentacic)
                medgeomsb = productosb ^ (1 / cuentasb)

                columna = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Promedio"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                If mediafosfbray <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(mediafosfbray, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If mediafosfcitrico <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(mediafosfcitrico, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If medianitratos <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medianitratos, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If mediaphagua <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(mediaphagua, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If mediaphkci <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(mediaphkci, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If mediapotasioint <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(mediapotasioint, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If mediasulfatos <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(mediapotasioint, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If medianitrogenoveg <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medianitrogenoveg, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If mediacarbonoorg <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(mediacarbonoorg, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If mediamateriaorg <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(mediamateriaorg, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If mediapmn <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(mediapmn, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If mediacalcio <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(mediacalcio, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If mediamagnesio <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(mediamagnesio, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If mediasodio <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(mediasodio, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If mediaacideztit <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(mediaacideztit, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If mediacic <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(mediacic, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If mediasb <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(mediasb, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = 1
                    fila = fila + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = 1
                    fila = fila + 1
                End If

                x1hoja.Cells(fila, columna).formula = "Desv. Estándar"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                If desvestfosfbray <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(desvestfosfbray, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If desvestfosfcitrico <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(desvestfosfcitrico, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If desvestnitratos <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(desvestnitratos, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If desvestphagua <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(desvestphagua, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If desvestphkci <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(desvestphkci, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If desvestpotasioint <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(desvestpotasioint, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If desvestsulfatos <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(desvestsulfatos, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If desvestnitrogenoveg <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(desvestnitrogenoveg, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If desvestcarbonoorg <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(desvestcarbonoorg, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If desvestmateriaorg <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(desvestmateriaorg, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If desvestpmn <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(desvestpmn, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If desvestcalcio <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(desvestcalcio, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If desvestmagnesio <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(desvestmagnesio, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If desvestsodio <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(desvestsodio, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If desvestacideztit <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(desvestacideztit, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If desvestcic <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(desvestcic, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If desvestsb <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(desvestsb, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = 1
                    fila = fila + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = 1
                    fila = fila + 1
                End If

                x1hoja.Cells(fila, columna).formula = "Media geom."
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                If medgeomfosfbray <> 1 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medgeomfosfbray, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If medgeomfosfcitrico <> 1 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medgeomfosfcitrico, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If medgeomnitratos <> 1 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medgeomnitratos, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If medgeomphagua <> 1 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medgeomphagua, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If medgeomphkci <> 1 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medgeomphkci, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If medgeompotasioint <> 1 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medgeompotasioint, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If medgeomsulfatos <> 1 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medgeomsulfatos, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If medgeomnitrogenoveg <> 1 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medgeomnitrogenoveg, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If medgeomcarbonoorg <> 1 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medgeomcarbonoorg, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If medgeommateriaorg <> 1 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medgeommateriaorg, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If medgeompmn <> 1 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medgeompmn, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If medgeomcalcio <> 1 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medgeomcalcio, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If medgeommagnesio <> 1 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medgeommagnesio, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If medgeomsodio <> 1 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medgeomsodio, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If medgeomacideztit <> 1 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medgeomacideztit, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If medgeomcic <> 1 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medgeomcic, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If medgeomsb <> 1 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medgeomsb, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = 1
                End If

            End If
        End If







        x1app.Visible = True
        'x1libro.PrintPreview()

        'x1hoja.PrintOut()
        'x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing

    End Sub
End Class