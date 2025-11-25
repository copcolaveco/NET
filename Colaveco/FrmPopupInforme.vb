Imports System.Data

Public Class FrmPopupInforme
    Inherits Form

    Private ReadOnly _datos As DatosPopupInforme

    ' Controles
    Private lblFichaVal, lblClienteVal, lblTipoMuestrasVal, lblAnalisisVal As Label
    Private lblCantMuestrasVal, lblTempVal, lblTipoLecheVal As Label
    Private txtObsInternas, txtObsInforme As TextBox
    Private lstCajas As ListBox
    Private dgvDetalle As DataGridView
    Private btnAceptar As Button
    Private txtLeyenda As TextBox


    Public Sub New(datos As DatosPopupInforme)
        Me._datos = datos
        Me.Text = "Resumen de Informe"
        Me.StartPosition = FormStartPosition.Manual      ' ← Manual para posicionar nosotros
        Me.FormBorderStyle = FormBorderStyle.FixedDialog  ' (podés usar Sizable si querés permitir redimensionar)
        Me.MinimizeBox = False
        Me.MaximizeBox = False
        Me.ShowInTaskbar = False
        Me.AutoScaleMode = AutoScaleMode.Font

        ' Ajusta la ventana al ~92% del área de trabajo del monitor activo
        SetAlmostFullscreen(0.92)

        ConstruirUI()
        CargarDatos()
    End Sub

    Private Sub SetAlmostFullscreen(Optional ByVal ratio As Double = 0.92)
        ' ratio entre 0.80 y 0.95 suele verse bien
        Dim scr As Screen
        If Me.Owner IsNot Nothing Then
            scr = Screen.FromControl(Me.Owner)
        Else
            scr = Screen.FromPoint(Cursor.Position)
        End If

        Dim wa As Rectangle = scr.WorkingArea ' área sin taskbar
        Dim w As Integer = CInt(Math.Max(800, wa.Width * ratio))   ' mínimo opcional 800x600
        Dim h As Integer = CInt(Math.Max(600, wa.Height * ratio))

        Dim x As Integer = wa.Left + (wa.Width - w) \ 2
        Dim y As Integer = wa.Top + (wa.Height - h) \ 2

        Me.Bounds = New Rectangle(x, y, w, h)
    End Sub



    Private Sub ConstruirUI()
        ' Layout simple con TableLayoutPanel arriba y panel para grilla abajo
        Dim tl As New TableLayoutPanel() With {
            .Dock = DockStyle.Top,
            .AutoSize = True,
            .ColumnCount = 4,
            .RowCount = 6,
            .Padding = New Padding(12),
            .AutoSizeMode = AutoSizeMode.GrowAndShrink
        }
        tl.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 140))
        tl.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50))
        tl.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 140))
        tl.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50))

        ' Helpers
        Dim fLabel As Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
        Dim fVal As Font = New Font("Segoe UI", 9.0!, FontStyle.Regular)

        ' Fila 0
        tl.Controls.Add(MakeLabel("Ficha:", fLabel), 0, 0)
        lblFichaVal = MakeValueLabel(fVal) : tl.Controls.Add(lblFichaVal, 1, 0)
        tl.Controls.Add(MakeLabel("Cliente:", fLabel), 2, 0)
        lblClienteVal = MakeValueLabel(fVal) : tl.Controls.Add(lblClienteVal, 3, 0)

        ' Fila 1
        tl.Controls.Add(MakeLabel("Tipo de muestras:", fLabel), 0, 1)
        lblTipoMuestrasVal = MakeValueLabel(fVal) : tl.Controls.Add(lblTipoMuestrasVal, 1, 1)
        tl.Controls.Add(MakeLabel("Análisis:", fLabel), 2, 1)
        lblAnalisisVal = MakeValueLabel(fVal) : tl.Controls.Add(lblAnalisisVal, 3, 1)

        ' Fila 2
        tl.Controls.Add(MakeLabel("Cant. muestras:", fLabel), 0, 2)
        lblCantMuestrasVal = MakeValueLabel(fVal) : tl.Controls.Add(lblCantMuestrasVal, 1, 2)
        tl.Controls.Add(MakeLabel("Temperatura:", fLabel), 2, 2)
        lblTempVal = MakeValueLabel(fVal) : tl.Controls.Add(lblTempVal, 3, 2)

        ' Fila 3
        tl.Controls.Add(MakeLabel("Tipo de leche:", fLabel), 0, 3)
        lblTipoLecheVal = MakeValueLabel(fVal) : tl.Controls.Add(lblTipoLecheVal, 1, 3)
        tl.Controls.Add(MakeLabel("Cajas:", fLabel), 2, 3)
        lstCajas = New ListBox() With {.Dock = DockStyle.Fill, .Height = 60}
        tl.Controls.Add(lstCajas, 3, 3)

        ' Fila 4 (Obs Internas)
        tl.Controls.Add(MakeLabel("Obs. Internas:", fLabel), 0, 4)
        txtObsInternas = New TextBox() With {
            .Dock = DockStyle.Fill, .Multiline = True, .Height = 60, .ReadOnly = True, .ScrollBars = ScrollBars.Vertical
        }
        tl.SetColumnSpan(txtObsInternas, 3)
        tl.Controls.Add(txtObsInternas, 1, 4)

        ' Fila 5 (Obs Informe)
        tl.Controls.Add(MakeLabel("Obs. Informe:", fLabel), 0, 5)
        txtObsInforme = New TextBox() With {
            .Dock = DockStyle.Fill, .Multiline = True, .Height = 60, .ReadOnly = True, .ScrollBars = ScrollBars.Vertical
        }
        tl.SetColumnSpan(txtObsInforme, 3)
        tl.Controls.Add(txtObsInforme, 1, 5)

        ' DataGridView detalle (id muestra / análisis)
        dgvDetalle = New DataGridView() With {
            .Dock = DockStyle.Fill,
            .AutoGenerateColumns = True,
            .ReadOnly = True,
            .AllowUserToAddRows = False,
            .AllowUserToDeleteRows = False,
            .RowHeadersVisible = False
        }

        ' --- Panel de leyenda (abajo, sobre los botones) ---
        Dim panelLeyenda As New Panel() With {
            .Dock = DockStyle.Bottom,
            .Height = 90,
            .Padding = New Padding(12)
        }
        Dim lblLeyenda As New Label() With {
            .Text = "Análisis solicitado:",
            .AutoSize = True,
            .Font = New Font("Segoe UI", 9.0!, FontStyle.Bold),
            .Dock = DockStyle.Top
        }
        txtLeyenda = New TextBox() With {
            .Dock = DockStyle.Fill,
            .Multiline = True,
            .ReadOnly = True,
            .ScrollBars = ScrollBars.Vertical
        }
        panelLeyenda.Controls.Add(txtLeyenda)
        panelLeyenda.Controls.Add(lblLeyenda)


        ' Panel inferior con botón Aceptar
        Dim panelBotones As New FlowLayoutPanel() With {
            .Dock = DockStyle.Bottom,
            .FlowDirection = FlowDirection.RightToLeft,
            .Height = 48,
            .Padding = New Padding(12)
        }
        btnAceptar = New Button() With {.Text = "Aceptar", .Width = 100, .Height = 30}
        AddHandler btnAceptar.Click, AddressOf btnAceptar_Click
        Me.AcceptButton = btnAceptar
        panelBotones.Controls.Add(btnAceptar)

        ' Agrego a la ventana
        Me.Controls.Add(dgvDetalle)
        Me.Controls.Add(panelLeyenda)
        Me.Controls.Add(panelBotones)
        Me.Controls.Add(tl)
    End Sub

    Private Sub CargarDatos()
        ' Labels
        lblFichaVal.Text = _datos.Ficha.ToString()

        lblClienteVal.Text = _datos.Cliente
        lblClienteVal.Font = New Font(lblClienteVal.Font.FontFamily, 16.0F, FontStyle.Bold)
        lblClienteVal.ForeColor = Color.Red
        lblClienteVal.AutoSize = True

        lblTipoMuestrasVal.Text = _datos.TipoMuestras
        lblAnalisisVal.Text = _datos.Analisis
        lblCantMuestrasVal.Text = _datos.CantidadMuestras.ToString()
        lblTempVal.Text = _datos.Temperatura

        lblTipoLecheVal.Text = _datos.TipoLeche
        lblTipoLecheVal.ForeColor = Color.Red
        lblTipoLecheVal.AutoSize = True

        txtObsInternas.Text = _datos.ObservacionesInternas
        txtObsInforme.Text = _datos.ObservacionesInforme

        ' Cajas
        If _datos.Cajas IsNot Nothing Then
            lstCajas.DataSource = _datos.Cajas
        End If

        ' Detalle (array de "IDMUESTRA||ANALISIS") → DataTable para el DataGridView
        dgvDetalle.DataSource = BuildDetalleTable(_datos.Detalle)
        If dgvDetalle.Columns.Contains("ID Muestra") Then
            dgvDetalle.Columns("ID Muestra").Width = 140
        End If
        If dgvDetalle.Columns.Contains("Análisis") Then
            dgvDetalle.Columns("Análisis").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End If

        ' Leyenda “Análisis solicitado”
        ' Si tenés el subtipoinforme disponible en el form, pasalo. Si no, podés pasar String.Empty.
        Dim subtipoinf As String = ""  ' ← reemplazá si lo tenés a mano
        txtLeyenda.Text = ConstruirLeyendaAnalisis(_datos.Ficha, subtipoinf)

    End Sub

    Private Function BuildDetalleTable(detalle As String()) As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("ID Muestra", GetType(String))
        dt.Columns.Add("Análisis", GetType(String))

        If detalle Is Nothing Then Return dt

        For Each s As String In detalle
            If s Is Nothing Then
                ' saltar item vacío
            Else
                Dim trimmed As String = s.Trim()
                If trimmed.Length > 0 Then
                    Dim parts As String() = trimmed.Split(New String() {"||"}, StringSplitOptions.None)
                    Dim idm As String = If(parts.Length > 0, parts(0).Trim(), "")
                    Dim ana As String = If(parts.Length > 1, parts(1).Trim(), "")
                    dt.Rows.Add(idm, ana)
                End If
            End If
        Next

        Return dt
    End Function

    Private Function MakeLabel(texto As String, f As Font) As Label
        Return New Label() With {.Text = texto, .AutoSize = True, .Font = f, .Margin = New Padding(0, 6, 6, 6)}
    End Function

    Private Function MakeValueLabel(f As Font) As Label
        Return New Label() With {.AutoSize = True, .Font = f, .Margin = New Padding(0, 6, 6, 6)}
    End Function

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs)
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    ' Construye la leyenda “Análisis solicitado” para la ficha
    Private Function ConstruirLeyendaAnalisis(ByVal ficha As Long, Optional ByVal subtipoinforme As String = "") As String
        Dim sb As New System.Text.StringBuilder()
        Dim na As New dNuevoAnalisis
        Dim listana As New ArrayList
        Dim listaanalisis As String = ""
        Dim listaanalisis2 As String = ""
        listana = na.listardistintosanalisis(ficha)

        If Not listana Is Nothing Then
            For Each na In listana

                Dim cantidad As Integer = 0
                Dim listacant As New ArrayList
                listacant = na.listarxfichaxanalisis(ficha, na.ANALISIS)
                cantidad = listacant.Count
                Dim lp As New dListaPrecios
                lp.ID = na.ANALISIS
                lp = lp.buscar
                listaanalisis = lp.ABREVIATURA & " ___/___/___ - _____ " & vbCrLf
                listaanalisis2 = listaanalisis2 & cantidad & " " & lp.ABREVIATURA & " - "


            Next
            If subtipoinforme = "Semen y Venereas" Then
                listaanalisis = "Evaluación biológica básica"
            End If
        Else
            If subtipoinforme = "Brucelosis" Then
                listaanalisis = "Brucelosis"
            End If
        End If

        '***  LISTADO DE ANALISIS TERCERIZADOS *********************************************************************
        Dim at As New dAnalisisTercerizado
        Dim listanat As New ArrayList
        Dim listaanalisist As String = ""
        listanat = at.listardistintosanalisis(ficha)
        If Not listanat Is Nothing Then
            Dim dep1 As Integer = 0
            Dim dep2 As Integer = 0
            For Each at In listanat
                Dim att As New dAnalisisTercerizadoTipo
                att.ID = at.ANALISIS
                att = att.buscar
                If att.DEPENDE <> 0 Then
                    dep1 = att.DEPENDE
                    Dim at2 As New dAnalisisTercerizadoTipo
                    at2.ID = att.DEPENDE
                    at2 = at2.buscar
                    If dep1 <> dep2 Then
                        listaanalisist = listaanalisist & at2.NOMBRE & " - "
                        at2 = Nothing
                    End If
                    dep2 = att.DEPENDE
                Else
                    listaanalisist = listaanalisist & att.NOMBRE & " - "
                End If
            Next
        End If
        If listaanalisist <> "" Then
            listaanalisis = listaanalisis & " / OTROS LABORATORIOS: " & listaanalisist
        End If
        sb.AppendLine(listaanalisis)
        sb.AppendLine(listaanalisis2)
        Return sb.ToString().TrimEnd()
    End Function

    Private Function QuitarSufijo(ByVal s As String, ByVal suf As String) As String
        If String.IsNullOrEmpty(s) OrElse String.IsNullOrEmpty(suf) Then Return s
        If s.EndsWith(suf) Then
            Return s.Substring(0, s.Length - suf.Length)
        End If
        Return s
    End Function
End Class
