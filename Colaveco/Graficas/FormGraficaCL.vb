Public Class FormGraficaCL
    Private ficha As Long
#Region "Constructores"
    Public Sub New(ByVal idficha As Long)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ficha = idficha
        ' graficar()
        'limpiar()
    End Sub

#End Region
    Private Sub graficar()
        Dim c As New dControl
        Dim lista As New ArrayList
        Dim muestrasreales As Integer = 0
        lista = c.listarporrc(ficha)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                muestrasreales = lista.Count
            Else
                MsgBox("No hay registros de esta ficha en la base de datos")
            End If
        Else
            MsgBox("No hay registros de esta ficha en la base de datos")
        End If


        Dim libreinfeccion As Integer = 0
        Dim posibleinfeccion As Integer = 0
        Dim probableinfeccion As Integer = 0

      
        For Each c In lista
            If c.RC < 150 Then
                libreinfeccion = libreinfeccion + 1
            ElseIf c.RC >= 150 And c.RC < 400 Then
                posibleinfeccion = posibleinfeccion + 1
            ElseIf c.RC >= 400 Then
                probableinfeccion = probableinfeccion + 1
            End If

        Next

        Dim vallibreinfeccion As Integer = 0
        Dim valposibleinfeccion As Integer = 0
        Dim valprobableinfeccion As Integer = 0
        Dim sumavalores As Integer = 0
        Dim diferenciavalores As Integer = 0

        vallibreinfeccion = (libreinfeccion / muestrasreales) * 100
        valposibleinfeccion = (posibleinfeccion / muestrasreales) * 100
        valprobableinfeccion = (probableinfeccion / muestrasreales) * 100

        sumavalores = vallibreinfeccion + valposibleinfeccion + valprobableinfeccion
        diferenciavalores = sumavalores - 100
        If diferenciavalores < 0 Then
            diferenciavalores = diferenciavalores * -1
        End If
        If sumavalores > 100 Then
            vallibreinfeccion = vallibreinfeccion - diferenciavalores
        ElseIf sumavalores < 100 Then
            vallibreinfeccion = vallibreinfeccion + diferenciavalores
        End If

        'GRAFICA RECUENTO CELULAS ******************************************************************************************************************************************
        Chart1.Titles.Clear()

        Chart1.Titles.Add("Interpretación de recuento celular")
        Chart1.Series(0).Points.Clear()
        'Chart1.Series(1).Points.Clear()

        Chart1.Series(0).Points.AddXY("Libre infección" & " " & vallibreinfeccion & " %", vallibreinfeccion)
        Chart1.Series(0).Points.AddXY("Posible infección" & " " & valposibleinfeccion & " %", valposibleinfeccion)
        Chart1.Series(0).Points.AddXY("Probable infección" & " " & valprobableinfeccion & " %", valprobableinfeccion)
        'Chart1.Series(1).Points.AddXY(c.FECHA, c.B1)

        Chart1.SaveImage("\\192.168.1.10\E\NET\CONTROL_LECHERO\Graficas\" & ficha & "_RC" & ".jpg", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Jpeg)
        '*******************************************************************************************************************************************************************
        Dim sa As New dSolicitudAnalisis
        Dim idproductor As Long = 0
        Dim ficha1 As Long = 0
        Dim ficha2 As Long = 0
        Dim ficha3 As Long = 0
        Dim listafichas As New ArrayList
        sa.ID = ficha
        sa = sa.buscar
        If Not sa Is Nothing Then
            idproductor = sa.IDPRODUCTOR
        End If
        listafichas = sa.listarporproductorultimas3(idproductor, ficha)
        If Not listafichas Is Nothing Then
            If listafichas.Count > 0 Then
                Dim i As Integer = 1
                For Each sa In listafichas
                    ficha1 = ficha
                    If i = 1 Then
                        ficha2 = sa.ID
                    ElseIf i = 2 Then
                        ficha3 = sa.ID
                        'ElseIf i = 3 Then
                        '    ficha3 = sa.ID
                    End If
                    i = i + 1
                Next
            End If
        End If

        Dim grasa1 As Double = 0
        Dim grasa2 As Double = 0
        Dim grasa3 As Double = 0
        Dim proteina1 As Double = 0
        Dim proteina2 As Double = 0
        Dim proteina3 As Double = 0
        Dim promediograsa1 As Double = 0
        Dim promediograsa2 As Double = 0
        Dim promediograsa3 As Double = 0
        Dim promedioproteina1 As Double = 0
        Dim promedioproteina2 As Double = 0
        Dim promedioproteina3 As Double = 0

        Dim c1 As New dControl
        Dim c2 As New dControl
        Dim c3 As New dControl
        Dim lista1 As New ArrayList
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        Dim muestras1 As Integer = 0
        Dim muestras2 As Integer = 0
        Dim muestras3 As Integer = 0
        lista1 = c1.listarxficha(ficha1)
        lista2 = c1.listarxficha(ficha2)
        lista3 = c1.listarxficha(ficha3)
        If Not lista1 Is Nothing Then
            muestras1 = lista1.Count
        End If
        If Not lista2 Is Nothing Then
            muestras2 = lista2.Count
        End If
        If Not lista3 Is Nothing Then
            muestras3 = lista3.Count
        End If
        If Not lista1 Is Nothing Then
            For Each c1 In lista1
                grasa1 = grasa1 + c1.GRASA
                proteina1 = proteina1 + c1.PROTEINA
            Next
        End If
        If Not lista2 Is Nothing Then
            For Each c2 In lista2
                grasa2 = grasa2 + c2.GRASA
                proteina2 = proteina2 + c2.PROTEINA
            Next
        End If
        If Not lista3 Is Nothing Then
            For Each c3 In lista3
                grasa3 = grasa3 + c3.GRASA
                proteina3 = proteina3 + c3.PROTEINA
            Next
        End If
        promediograsa1 = Math.Round(grasa1 / muestras1, 2)
        promedioproteina1 = Math.Round(proteina1 / muestras1, 2)
        promediograsa2 = Math.Round(grasa2 / muestras2, 2)
        promedioproteina2 = Math.Round(proteina2 / muestras2, 2)
        promediograsa3 = Math.Round(grasa3 / muestras3, 2)
        promedioproteina3 = Math.Round(proteina3 / muestras3, 2)


        'GRAFICA GRASA ******************************************************************************************************************************************

        Chart2.Titles.Clear()

        Chart2.Titles.Add("Promedios de grasa de los últimos 3 controles")
        Chart2.Series(0).Points.Clear()
        'Chart1.Series(1).Points.Clear()

        Chart2.Series(0).Points.AddXY("1", promediograsa1)
        Chart2.Series(0).Label = promediograsa1
        Chart2.Series(0).Name = promediograsa1
        Chart2.Series(0).LegendText = "Control actual"
        Chart2.Series(1).Points.AddXY("2", promediograsa2)
        Chart2.Series(1).Label = promediograsa2
        Chart2.Series(1).Name = "2"
        Chart2.Series(2).Points.AddXY("3", promediograsa3)
        Chart2.Series(2).Label = promediograsa3
        Chart2.Series(2).Name = "3"
        'Chart1.Series(1).Points.AddXY(c.FECHA, c.B1)

        Chart2.SaveImage("\\192.168.1.10\E\NET\CONTROL_LECHERO\Graficas\" & ficha & "_Grasa" & ".jpg", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Jpeg)
        'GRAFICA PROTEINA ******************************************************************************************************************************************
        Chart3.Titles.Clear()

        Chart3.Titles.Add("Promedios de proteínas de los últimos 3 controles")
        Chart3.Series(0).Points.Clear()
        'Chart1.Series(1).Points.Clear()

        Chart3.Series(0).Points.AddXY("1", promedioproteina1)
        Chart3.Series(0).Label = promedioproteina1
        'Chart3.Series(0).Name = promedioproteina1
        Chart3.Series(0).LegendText = "Control actual"
        Chart3.Series(1).Points.AddXY("2", promedioproteina2)
        Chart3.Series(1).Label = promedioproteina2
        Chart3.Series(1).Name = "2"
        Chart3.Series(2).Points.AddXY("3", promedioproteina3)
        Chart3.Series(2).Label = promedioproteina3
        Chart3.Series(2).Name = "3"
        'Chart1.Series(1).Points.AddXY(c.FECHA, c.B1)

        Chart3.SaveImage("\\192.168.1.10\E\NET\CONTROL_LECHERO\Graficas\" & ficha & "_Proteina" & ".jpg", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Jpeg)
    End Sub
   
End Class