
Public Class FormMaterialReferenciaMedias

#Region "Constructores"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ComboItem.Text = "Células"
        ComboEquipo.Text = "Bentley"


    End Sub

#End Region
    Private Sub ButtonGraficar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGraficar.Click
        Chart1.Titles.Clear()
        Chart2.Titles.Clear()
        graficar1()
        graficar2()
    End Sub
    Private Sub graficar1()
        Dim mrm As New dMaterialReferenciaMedias
        Dim fechadesde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim fechahasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecd As String
        Dim fech As String
        fecd = Format(fechadesde, "yyyy-MM-dd")
        fech = Format(fechahasta, "yyyy-MM-dd")
        Dim item As String = ComboItem.Text
        Dim equipo As String = ComboEquipo.Text
        Dim itemx As String = ""

        Dim lista As New ArrayList
        Dim lista2 As New ArrayList

        If item = "Células" Then
            itemx = "celulas"
            Chart1.Titles.Add("Células (sin ajustes)")
        ElseIf item = "Grasa" Then
            itemx = "grasa"
            Chart1.Titles.Add("Grasa (sin ajustes)")
        ElseIf item = "Proteína" Then
            itemx = "proteina"
            Chart1.Titles.Add("Proteína (sin ajustes)")
        ElseIf item = "Lactosa" Then
            itemx = "lactosa"
            Chart1.Titles.Add("Lactosa (sin ajustes)")
        ElseIf item = "Sólidos totales" Then
            itemx = "st"
            Chart1.Titles.Add("Sólidos totales (sin ajustes)")
        ElseIf item = "Crioscopía" Then
            itemx = "crioscopia"
            Chart1.Titles.Add("Crioscopía (sin ajustes)")
        ElseIf item = "Urea" Then
            itemx = "urea"
            Chart1.Titles.Add("Urea (sin ajustes)")
        ElseIf item = "Proteína verdadera" Then
            itemx = "proteinav"
            Chart1.Titles.Add("Proteína verdadera (sin ajustes)")
        ElseIf item = "Caseína" Then
            itemx = "caseina"
            Chart1.Titles.Add("Caseína (sin ajustes)")
        ElseIf item = "Densidad" Then
            itemx = "densidad"
            Chart1.Titles.Add("Densidad (sin ajustes)")
        ElseIf item = "pH" Then
            itemx = "ph"
            Chart1.Titles.Add("pH (sin ajustes)")
        ElseIf item = "Citratos" Then
            itemx = "citratos"
            Chart1.Titles.Add("Citratos (sin ajustes)")
        End If


        lista = mrm.listarxitem(fecd, fech, itemx, equipo)
        Chart1.Series(0).Points.Clear()
        Chart1.Series(1).Points.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each mrm In lista
                    Chart1.Series(0).Points.AddXY(mrm.FECHA, mrm.LECTURA)
                    Chart1.Series(1).Points.AddXY(mrm.FECHA, mrm.LECTURA)
                Next
            End If
        End If
        mrm = Nothing
        lista = Nothing
        lista2 = Nothing
    End Sub
    Private Sub graficar2()
       

        Dim fechadesde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim fechahasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecd As String
        Dim fech As String
        fecd = Format(fechadesde, "yyyy-MM-dd")
        fech = Format(fechahasta, "yyyy-MM-dd")
        Dim item As String = ComboItem.Text
        Dim equipo As String = ComboEquipo.Text
        Dim itemx As String = ""



        If item = "Células" Then
            itemx = "celulas"
            Chart2.Titles.Add("Células (con ajustes)")
        ElseIf item = "Grasa" Then
            itemx = "grasa"
            Chart2.Titles.Add("Grasa (con ajustes)")
        ElseIf item = "Proteína" Then
            itemx = "proteina"
            Chart2.Titles.Add("Proteína (con ajustes)")
        ElseIf item = "Lactosa" Then
            itemx = "lactosa"
            Chart2.Titles.Add("Lactosa (con ajustes)")
        ElseIf item = "Sólidos totales" Then
            itemx = "st"
            Chart2.Titles.Add("Sólidos totales (con ajustes)")
        ElseIf item = "Crioscopía" Then
            itemx = "crioscopia"
            Chart2.Titles.Add("Crioscopía (con ajustes)")
        ElseIf item = "Urea" Then
            itemx = "urea"
            Chart2.Titles.Add("Urea (con ajustes)")
        ElseIf item = "Proteína verdadera" Then
            itemx = "proteinav"
            Chart2.Titles.Add("Proteína verdadera (con ajustes)")
        ElseIf item = "Caseína" Then
            itemx = "caseina"
            Chart2.Titles.Add("Caseína (con ajustes)")
        ElseIf item = "Densidad" Then
            itemx = "densidad"
            Chart2.Titles.Add("Densidad (con ajustes)")
        ElseIf item = "pH" Then
            itemx = "ph"
            Chart2.Titles.Add("pH (con ajustes)")
        ElseIf item = "Citratos" Then
            itemx = "citratos"
            Chart2.Titles.Add("Citratos (con ajustes)")
        End If


        Dim mrm As New dMaterialReferenciaMedias
        Dim mrm2 As New dMaterialReferenciaMedias
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList


        lista = mrm.listarxitem(fecd, fech, itemx, equipo)
        lista2 = mrm2.listarxitem(fecd, fech, itemx, equipo)
        Dim repite As Integer = 0
        If Not lista Is Nothing Then
            For Each mrm In lista
                For Each mrm2 In lista2
                    If mrm.FECHA = mrm2.FECHA And mrm.OPERADOR = mrm2.OPERADOR And mrm.EQUIPO = mrm2.EQUIPO And mrm.ITEM = mrm2.ITEM And mrm2.PASADA = 2 Then
                        repite = 1
                        Exit For
                    Else
                        repite = 0
                    End If
                Next
                'guarda las primeras pasadas que no tengan una segunda.
                If repite = 0 Then
                    lista3.Add(mrm)
                End If
            Next
            'Guarda las segundas pasadas
            For Each mrm In lista
                Dim contador As Integer = 1
                If mrm.PASADA = 2 Then
                    lista3.Add(mrm)
                    contador = contador + 1
                End If
            Next
        End If
        'Guarda en la tabla auxiliar
        If Not lista3 Is Nothing Then
            If lista3.Count > 0 Then
                Dim mrm_aux As New dMaterialReferenciaAux
                mrm_aux.vaciar()
                For Each mrm In lista3

                    Dim fecha As Date = mrm.FECHA
                    Dim fec As String
                    fec = Format(fecha, "yyyy-MM-dd")

                    mrm_aux.FECHA = fec
                    mrm_aux.OPERADOR = mrm.OPERADOR
                    mrm_aux.EQUIPO = mrm.EQUIPO
                    mrm_aux.ITEM = mrm.ITEM
                    mrm_aux.LECTURA = mrm.LECTURA
                    mrm_aux.PASADA = mrm.PASADA
                    mrm_aux.guardar()
                Next
            End If
        End If

        Dim mrm_aux2 As New dMaterialReferenciaAux
        Dim lista4 As New ArrayList
        lista4 = mrm_aux2.listar

        Chart2.Series(0).Points.Clear()
        Chart2.Series(1).Points.Clear()
        If Not lista4 Is Nothing Then
            If lista4.Count > 0 Then
                For Each mrm_aux2 In lista4
                    Chart2.Series(0).Points.AddXY(mrm_aux2.FECHA, mrm_aux2.LECTURA)
                    Chart2.Series(1).Points.AddXY(mrm_aux2.FECHA, mrm_aux2.LECTURA)
                Next
            End If
        End If
        mrm = Nothing
        mrm2 = Nothing
        mrm_aux2 = Nothing
        lista = Nothing
        lista2 = Nothing
        lista3 = Nothing
        lista4 = Nothing
    End Sub
    
    Private Sub ButtonVerValores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonVerValores.Click

        Dim fechadesde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim fechahasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecd As String
        Dim fech As String
        fecd = Format(fechadesde, "yyyy-MM-dd")
        fech = Format(fechahasta, "yyyy-MM-dd")
        Dim item As String = ComboItem.Text
        Dim equipo As String = ComboEquipo.Text
        Dim itemx As String = ""


        If item = "Células" Then
            itemx = "celulas"
        ElseIf item = "Grasa" Then
            itemx = "grasa"
        ElseIf item = "Proteína" Then
            itemx = "proteina"
        ElseIf item = "Lactosa" Then
            itemx = "lactosa"
        ElseIf item = "Sólidos totales" Then
            itemx = "st"
        ElseIf item = "Crioscopía" Then
            itemx = "crioscopia"
        ElseIf item = "Urea" Then
            itemx = "urea"
        ElseIf item = "Proteína verdadera" Then
            itemx = "proteinav"
        ElseIf item = "Caseína" Then
            itemx = "caseina"
        ElseIf item = "Densidad" Then
            itemx = "densidad"
        ElseIf item = "pH" Then
            itemx = "ph"
        ElseIf item = "Citratos" Then
            itemx = "citratos"
        End If

        Dim v As New FormVerMaterialRefMedias(fecd, fech, itemx, equipo)
        v.ShowDialog()


    End Sub
End Class