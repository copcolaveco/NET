Public Class FormGraficaControl
#Region "Constructores"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        graficar()

    End Sub
#End Region
    Private Sub graficar()
        Dim r As New dResultadosBD
        Dim lista As New ArrayList
        lista = r.listarultimos2
        Dim vmgrasa1 As Double = 0
        Dim vmgrasa2 As Double = 0
        Dim vmproteina1 As Double = 0
        Dim vmproteina2 As Double = 0
        Dim vmlactosa1 As Double = 0
        Dim vmlactosa2 As Double = 0
        Dim vmstotales1 As Double = 0
        Dim vmstotales2 As Double = 0
        Dim vmcelulas1 As Double = 0
        Dim vmcelulas2 As Double = 0
        Dim vmcrioscopia1 As Double = 0
        Dim vmcrioscopia2 As Double = 0
        Dim vmurea1 As Double = 0
        Dim vmurea2 As Double = 0
        Dim grasa1 As Double = 0
        Dim grasa2 As Double = 0
        Dim proteina1 As Double = 0
        Dim proteina2 As Double = 0
        Dim lactosa1 As Double = 0
        Dim lactosa2 As Double = 0
        Dim stotales1 As Double = 0
        Dim stotales2 As Double = 0
        Dim celulas1 As Double = 0
        Dim celulas2 As Double = 0
        Dim crioscopia1 As Double = 0
        Dim crioscopia2 As Double = 0
        Dim urea1 As Double = 0
        Dim urea2 As Double = 0
        Dim contador As Integer = 1
        Dim c1 As Double = 0
        Dim c2 As Double = 0
        If Not lista Is Nothing Then
            For Each r In lista
                If contador = 1 Then
                    vmgrasa1 = r.MGR
                    vmproteina1 = r.MPR
                    vmlactosa1 = r.MLA
                    vmstotales1 = r.MST
                    vmcelulas1 = r.MCE
                    vmcrioscopia1 = r.MCR
                    vmurea1 = r.MUR
                    grasa1 = r.GRASA
                    proteina1 = r.PROTEINA
                    lactosa1 = r.LACTOSA
                    stotales1 = r.SOLTOTALES
                    celulas1 = r.CELULAS
                    crioscopia1 = r.CRIOSCOPIA
                    urea1 = r.UREA
                    TextGrasa1.Text = grasa1
                    TextProteina1.Text = proteina1
                    TextLactosa1.Text = lactosa1
                    TextSTotales1.Text = stotales1
                    TextCelulas1.Text = celulas1
                    TextCrioscopia1.Text = crioscopia1
                    TextUrea1.Text = urea1
                    If grasa1 >= 0 Then
                        If grasa1 <= 0.05 Then
                            TextGrasa1.BackColor = Color.Green
                            TextGrasa1.ForeColor = Color.White
                        ElseIf grasa1 > 0.05 And grasa1 <= 0.08 Then
                            TextGrasa1.BackColor = Color.Yellow
                        ElseIf grasa1 > 0.08 Then
                            TextGrasa1.BackColor = Color.Red
                            TextGrasa1.ForeColor = Color.White
                        End If
                    Else
                        If grasa1 >= -0.05 Then
                            TextGrasa1.BackColor = Color.Green
                            TextGrasa1.ForeColor = Color.White
                        ElseIf grasa1 < -0.05 And grasa1 >= -0.08 Then
                            TextGrasa1.BackColor = Color.Yellow
                        ElseIf grasa1 < -0.08 Then
                            TextGrasa1.BackColor = Color.Red
                            TextGrasa1.ForeColor = Color.White
                        End If
                    End If
                    If proteina1 >= 0 Then
                        If proteina1 <= 0.05 Then
                            TextProteina1.BackColor = Color.Green
                            TextProteina1.ForeColor = Color.White
                        ElseIf proteina1 > 0.05 And proteina1 <= 0.08 Then
                            TextProteina1.BackColor = Color.Yellow
                        ElseIf proteina1 > 0.08 Then
                            TextProteina1.BackColor = Color.Red
                            TextProteina1.ForeColor = Color.White
                        End If
                    Else
                        If proteina1 >= -0.05 Then
                            TextProteina1.BackColor = Color.Green
                            TextProteina1.ForeColor = Color.White
                        ElseIf proteina1 < -0.05 And proteina1 >= -0.08 Then
                            TextProteina1.BackColor = Color.Yellow
                        ElseIf proteina1 < -0.08 Then
                            TextProteina1.BackColor = Color.Red
                            TextProteina1.ForeColor = Color.White
                        End If
                    End If
                    If lactosa1 >= 0 Then
                        If lactosa1 <= 0.05 Then
                            TextLactosa1.BackColor = Color.Green
                            TextLactosa1.ForeColor = Color.White
                        ElseIf lactosa1 > 0.05 And lactosa1 <= 0.08 Then
                            TextLactosa1.BackColor = Color.Yellow
                        ElseIf lactosa1 > 0.08 Then
                            TextLactosa1.BackColor = Color.Red
                            TextLactosa1.ForeColor = Color.White
                        End If
                    Else
                        If lactosa1 >= -0.05 Then
                            TextLactosa1.BackColor = Color.Green
                            TextLactosa1.ForeColor = Color.White
                        ElseIf lactosa1 < -0.05 And lactosa1 >= -0.08 Then
                            TextLactosa1.BackColor = Color.Yellow
                        ElseIf lactosa1 < -0.08 Then
                            TextLactosa1.BackColor = Color.Red
                            TextLactosa1.ForeColor = Color.White
                        End If
                    End If
                    If stotales1 >= 0 Then
                        If stotales1 <= 0.15 Then
                            TextSTotales1.BackColor = Color.Green
                            TextSTotales1.ForeColor = Color.White
                        ElseIf stotales1 > 0.15 And stotales1 <= 0.25 Then
                            TextSTotales1.BackColor = Color.Yellow
                        ElseIf stotales1 > 0.25 Then
                            TextSTotales1.BackColor = Color.Red
                            TextSTotales1.ForeColor = Color.White
                        End If
                    Else
                        If stotales1 >= -0.15 Then
                            TextSTotales1.BackColor = Color.Green
                            TextSTotales1.ForeColor = Color.White
                        ElseIf stotales1 < -0.15 And stotales1 >= -0.25 Then
                            TextSTotales1.BackColor = Color.Yellow
                        ElseIf stotales1 < -0.25 Then
                            TextSTotales1.BackColor = Color.Red
                            TextSTotales1.ForeColor = Color.White
                        End If
                    End If
                    c1 = vmcelulas1
                    c2 = (celulas1 / c1) * 100
                    If c2 >= 0 Then
                        If c2 <= 5 Then
                            TextCelulas1.BackColor = Color.Green
                            TextCelulas1.ForeColor = Color.White
                        ElseIf c2 > 5 And c2 <= 10 Then
                            TextCelulas1.BackColor = Color.Yellow
                        ElseIf c2 > 10 Then
                            TextCelulas1.BackColor = Color.Red
                            TextCelulas1.ForeColor = Color.White
                        End If
                    Else
                        If c2 >= -5 Then
                            TextCelulas1.BackColor = Color.Green
                            TextCelulas1.ForeColor = Color.White
                        ElseIf c2 < -5 And c2 >= -10 Then
                            TextCelulas1.BackColor = Color.Yellow
                        ElseIf c2 < -10 Then
                            TextCelulas1.BackColor = Color.Red
                            TextCelulas1.ForeColor = Color.White
                        End If
                    End If
                    If crioscopia1 >= 0 Then
                        If crioscopia1 <= 5 Then
                            TextCrioscopia1.BackColor = Color.Green
                            TextCrioscopia1.ForeColor = Color.White
                        ElseIf crioscopia1 > 5 And crioscopia1 <= 10 Then
                            TextCrioscopia1.BackColor = Color.Yellow
                        ElseIf crioscopia1 > 10 Then
                            TextCrioscopia1.BackColor = Color.Red
                            TextCrioscopia1.ForeColor = Color.White
                        End If
                    Else
                        If crioscopia1 >= -5 Then
                            TextCrioscopia1.BackColor = Color.Green
                            TextCrioscopia1.ForeColor = Color.White
                        ElseIf crioscopia1 < -5 And crioscopia1 >= -10 Then
                            TextCrioscopia1.BackColor = Color.Yellow
                        ElseIf crioscopia1 < -10 Then
                            TextCrioscopia1.BackColor = Color.Red
                            TextCrioscopia1.ForeColor = Color.White
                        End If
                    End If
                    If urea1 >= 0 Then
                        If urea1 <= 4 Then
                            TextUrea1.BackColor = Color.Green
                            TextUrea1.ForeColor = Color.White
                        ElseIf urea1 > 4 And urea1 <= 8 Then
                            TextUrea1.BackColor = Color.Yellow
                        ElseIf urea1 > 8 Then
                            TextUrea1.BackColor = Color.Red
                            TextUrea1.ForeColor = Color.White
                        End If
                    Else
                        If urea1 >= -4 Then
                            TextUrea1.BackColor = Color.Green
                            TextUrea1.ForeColor = Color.White
                        ElseIf urea1 < -4 And urea1 >= -8 Then
                            TextUrea1.BackColor = Color.Yellow
                        ElseIf urea1 < -8 Then
                            TextUrea1.BackColor = Color.Red
                            TextUrea1.ForeColor = Color.White
                        End If
                    End If
                ElseIf contador = 2 Then
                    vmgrasa2 = r.MGR
                    vmproteina2 = r.MPR
                    vmlactosa2 = r.MLA
                    vmstotales2 = r.MST
                    vmcelulas2 = r.MCE
                    vmcrioscopia2 = r.MCR
                    vmurea2 = r.MUR
                    grasa2 = r.GRASA
                    proteina2 = r.PROTEINA
                    lactosa2 = r.LACTOSA
                    stotales2 = r.SOLTOTALES
                    celulas2 = r.CELULAS
                    crioscopia2 = r.CRIOSCOPIA
                    urea2 = r.UREA
                    TextGrasa2.Text = grasa2
                    TextProteina2.Text = proteina2
                    TextLactosa2.Text = lactosa2
                    TextSTotales2.Text = stotales2
                    TextCelulas2.Text = celulas2
                    TextCrioscopia2.Text = crioscopia2
                    TextUrea2.Text = urea2
                    If grasa2 >= 0 Then
                        If grasa2 <= 0.05 Then
                            TextGrasa2.BackColor = Color.Green
                            TextGrasa2.ForeColor = Color.White
                        ElseIf grasa2 > 0.05 And grasa2 <= 0.08 Then
                            TextGrasa2.BackColor = Color.Yellow
                        ElseIf grasa2 > 0.08 Then
                            TextGrasa2.BackColor = Color.Red
                            TextGrasa2.ForeColor = Color.White
                        End If
                    Else
                        If grasa2 >= -0.05 Then
                            TextGrasa2.BackColor = Color.Green
                            TextGrasa2.ForeColor = Color.White
                        ElseIf grasa2 < -0.05 And grasa2 >= -0.08 Then
                            TextGrasa2.BackColor = Color.Yellow
                        ElseIf grasa2 < -0.08 Then
                            TextGrasa2.BackColor = Color.Red
                            TextGrasa2.ForeColor = Color.White
                        End If
                    End If
                    If proteina2 >= 0 Then
                        If proteina2 <= 0.05 Then
                            TextProteina2.BackColor = Color.Green
                            TextProteina2.ForeColor = Color.White
                        ElseIf proteina2 > 0.05 And proteina2 <= 0.08 Then
                            TextProteina2.BackColor = Color.Yellow
                        ElseIf proteina2 > 0.08 Then
                            TextProteina2.BackColor = Color.Red
                            TextProteina2.ForeColor = Color.White
                        End If
                    Else
                        If proteina2 >= -0.05 Then
                            TextProteina2.BackColor = Color.Green
                            TextProteina2.ForeColor = Color.White
                        ElseIf proteina2 < -0.05 And proteina2 >= -0.08 Then
                            TextProteina2.BackColor = Color.Yellow
                        ElseIf proteina2 < -0.08 Then
                            TextProteina2.BackColor = Color.Red
                            TextProteina2.ForeColor = Color.White
                        End If
                    End If
                    If lactosa2 >= 0 Then
                        If lactosa2 <= 0.05 Then
                            TextLactosa2.BackColor = Color.Green
                            TextLactosa2.ForeColor = Color.White
                        ElseIf lactosa2 > 0.05 And lactosa2 <= 0.08 Then
                            TextLactosa2.BackColor = Color.Yellow
                        ElseIf lactosa2 > 0.08 Then
                            TextLactosa2.BackColor = Color.Red
                            TextLactosa2.ForeColor = Color.White
                        End If
                    Else
                        If lactosa2 >= -0.05 Then
                            TextLactosa2.BackColor = Color.Green
                            TextLactosa2.ForeColor = Color.White
                        ElseIf lactosa2 < -0.05 And lactosa2 >= -0.08 Then
                            TextLactosa2.BackColor = Color.Yellow
                        ElseIf lactosa2 < -0.08 Then
                            TextLactosa2.BackColor = Color.Red
                            TextLactosa2.ForeColor = Color.White
                        End If
                    End If
                    If stotales2 >= 0 Then
                        If stotales2 <= 0.15 Then
                            TextSTotales2.BackColor = Color.Green
                            TextSTotales2.ForeColor = Color.White
                        ElseIf stotales2 > 0.15 And stotales2 <= 0.25 Then
                            TextSTotales2.BackColor = Color.Yellow
                        ElseIf stotales2 > 0.25 Then
                            TextSTotales2.BackColor = Color.Red
                            TextSTotales2.ForeColor = Color.White
                        End If
                    Else
                        If stotales2 >= -0.15 Then
                            TextSTotales2.BackColor = Color.Green
                            TextSTotales2.ForeColor = Color.White
                        ElseIf stotales2 < -0.15 And stotales2 >= -0.25 Then
                            TextSTotales2.BackColor = Color.Yellow
                        ElseIf stotales2 < -0.25 Then
                            TextSTotales2.BackColor = Color.Red
                            TextSTotales2.ForeColor = Color.White
                        End If
                    End If
                    c1 = vmcelulas2
                    c2 = (celulas2 / c1) * 100
                    If c2 >= 0 Then
                        If c2 <= 5 Then
                            TextCelulas2.BackColor = Color.Green
                            TextCelulas2.ForeColor = Color.White
                        ElseIf c2 > 5 And c2 <= 10 Then
                            TextCelulas2.BackColor = Color.Yellow
                        ElseIf c2 > 10 Then
                            TextCelulas2.BackColor = Color.Red
                            TextCelulas2.ForeColor = Color.White
                        End If
                    Else
                        If c2 >= -5 Then
                            TextCelulas2.BackColor = Color.Green
                            TextCelulas2.ForeColor = Color.White
                        ElseIf c2 < -5 And c2 >= -10 Then
                            TextCelulas2.BackColor = Color.Yellow
                        ElseIf c2 < -10 Then
                            TextCelulas2.BackColor = Color.Red
                            TextCelulas2.ForeColor = Color.White
                        End If
                    End If
                    If crioscopia2 >= 0 Then
                        If crioscopia2 <= 5 Then
                            TextCrioscopia2.BackColor = Color.Green
                            TextCrioscopia2.ForeColor = Color.White
                        ElseIf crioscopia2 > 5 And crioscopia2 <= 10 Then
                            TextCrioscopia2.BackColor = Color.Yellow
                        ElseIf crioscopia2 > 10 Then
                            TextCrioscopia2.BackColor = Color.Red
                            TextCrioscopia2.ForeColor = Color.White
                        End If
                    Else
                        If crioscopia2 >= -5 Then
                            TextCrioscopia2.BackColor = Color.Green
                            TextCrioscopia2.ForeColor = Color.White
                        ElseIf crioscopia2 < -5 And crioscopia2 >= -10 Then
                            TextCrioscopia2.BackColor = Color.Yellow
                        ElseIf crioscopia2 < -10 Then
                            TextCrioscopia2.BackColor = Color.Red
                            TextCrioscopia2.ForeColor = Color.White
                        End If
                    End If
                    If urea2 >= 0 Then
                        If urea2 <= 4 Then
                            TextUrea2.BackColor = Color.Green
                            TextUrea2.ForeColor = Color.White
                        ElseIf urea2 > 4 And urea2 <= 8 Then
                            TextUrea2.BackColor = Color.Yellow
                        ElseIf urea2 > 8 Then
                            TextUrea2.BackColor = Color.Red
                            TextUrea2.ForeColor = Color.White
                        End If
                    Else
                        If urea2 >= -4 Then
                            TextUrea2.BackColor = Color.Green
                            TextUrea2.ForeColor = Color.White
                        ElseIf urea2 < -4 And urea2 >= -8 Then
                            TextUrea2.BackColor = Color.Yellow
                        ElseIf urea2 < -8 Then
                            TextUrea2.BackColor = Color.Red
                            TextUrea2.ForeColor = Color.White
                        End If
                    End If
                End If
                contador = 2
            Next
        End If
    End Sub
End Class