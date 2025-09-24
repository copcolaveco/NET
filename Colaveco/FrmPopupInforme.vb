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

    Public Sub New(datos As DatosPopupInforme)
        Me._datos = datos
        Me.Text = "Resumen de Informe"
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.MaximizeBox = False
        Me.ShowInTaskbar = False
        Me.Width = 900
        Me.Height = 650

        ConstruirUI()
        CargarDatos()
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
End Class
