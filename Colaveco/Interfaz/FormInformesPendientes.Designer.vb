<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInformesPendientes
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ButtonImprimir = New System.Windows.Forms.Button()
        Me.DateHoy = New System.Windows.Forms.DateTimePicker()
        Me.DateSolicitud = New System.Windows.Forms.DateTimePicker()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Informe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ficha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Muestras = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextControl = New System.Windows.Forms.TextBox()
        Me.TextCalidad = New System.Windows.Forms.TextBox()
        Me.TextAgua = New System.Windows.Forms.TextBox()
        Me.TextAntibiograma = New System.Windows.Forms.TextBox()
        Me.TextPal = New System.Windows.Forms.TextBox()
        Me.TextAmbiental = New System.Windows.Forms.TextBox()
        Me.TextPatologia = New System.Windows.Forms.TextBox()
        Me.TextSerologiaLeucosis = New System.Windows.Forms.TextBox()
        Me.TextProductos = New System.Windows.Forms.TextBox()
        Me.TextParasitologia = New System.Windows.Forms.TextBox()
        Me.TextOtros = New System.Windows.Forms.TextBox()
        Me.TextAgroNutricion = New System.Windows.Forms.TextBox()
        Me.TextLactometros = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextAgroSuelos = New System.Windows.Forms.TextBox()
        Me.TextBrucelosisLeche = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TextSerologiaBrucelosis = New System.Windows.Forms.TextBox()
        Me.TextSerologiaOtros = New System.Windows.Forms.TextBox()
        Me.TextSPSalmonellaListeria = New System.Windows.Forms.TextBox()
        Me.TextSPMohosLevaduras = New System.Windows.Forms.TextBox()
        Me.TextEsporulados = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TextEfluentes = New System.Windows.Forms.TextBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonImprimir
        '
        Me.ButtonImprimir.Location = New System.Drawing.Point(1029, 638)
        Me.ButtonImprimir.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonImprimir.Name = "ButtonImprimir"
        Me.ButtonImprimir.Size = New System.Drawing.Size(100, 28)
        Me.ButtonImprimir.TabIndex = 1
        Me.ButtonImprimir.Text = "Imprimir"
        Me.ButtonImprimir.UseVisualStyleBackColor = True
        '
        'DateHoy
        '
        Me.DateHoy.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateHoy.Location = New System.Drawing.Point(915, 9)
        Me.DateHoy.Margin = New System.Windows.Forms.Padding(4)
        Me.DateHoy.Name = "DateHoy"
        Me.DateHoy.Size = New System.Drawing.Size(128, 22)
        Me.DateHoy.TabIndex = 2
        Me.DateHoy.Visible = False
        '
        'DateSolicitud
        '
        Me.DateSolicitud.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateSolicitud.Location = New System.Drawing.Point(1052, 9)
        Me.DateSolicitud.Margin = New System.Windows.Forms.Padding(4)
        Me.DateSolicitud.Name = "DateSolicitud"
        Me.DateSolicitud.Size = New System.Drawing.Size(131, 22)
        Me.DateSolicitud.TabIndex = 3
        Me.DateSolicitud.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Informe, Me.Ficha, Me.Muestras})
        Me.DataGridView1.Location = New System.Drawing.Point(16, 235)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(1113, 395)
        Me.DataGridView1.TabIndex = 4
        '
        'Column1
        '
        Me.Column1.HeaderText = "Fecha solicitud"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Atraso (dias)"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 70
        '
        'Column3
        '
        Me.Column3.HeaderText = "Productor"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 350
        '
        'Informe
        '
        Me.Informe.HeaderText = "Informe"
        Me.Informe.Name = "Informe"
        Me.Informe.Width = 200
        '
        'Ficha
        '
        Me.Ficha.HeaderText = "Ficha"
        Me.Ficha.Name = "Ficha"
        '
        'Muestras
        '
        Me.Muestras.HeaderText = "Muestras"
        Me.Muestras.Name = "Muestras"
        Me.Muestras.ReadOnly = True
        '
        'TextControl
        '
        Me.TextControl.Location = New System.Drawing.Point(128, 15)
        Me.TextControl.Margin = New System.Windows.Forms.Padding(4)
        Me.TextControl.Name = "TextControl"
        Me.TextControl.Size = New System.Drawing.Size(52, 22)
        Me.TextControl.TabIndex = 5
        '
        'TextCalidad
        '
        Me.TextCalidad.Location = New System.Drawing.Point(128, 47)
        Me.TextCalidad.Margin = New System.Windows.Forms.Padding(4)
        Me.TextCalidad.Name = "TextCalidad"
        Me.TextCalidad.Size = New System.Drawing.Size(52, 22)
        Me.TextCalidad.TabIndex = 6
        '
        'TextAgua
        '
        Me.TextAgua.Location = New System.Drawing.Point(128, 79)
        Me.TextAgua.Margin = New System.Windows.Forms.Padding(4)
        Me.TextAgua.Name = "TextAgua"
        Me.TextAgua.Size = New System.Drawing.Size(52, 22)
        Me.TextAgua.TabIndex = 7
        '
        'TextAntibiograma
        '
        Me.TextAntibiograma.Location = New System.Drawing.Point(128, 111)
        Me.TextAntibiograma.Margin = New System.Windows.Forms.Padding(4)
        Me.TextAntibiograma.Name = "TextAntibiograma"
        Me.TextAntibiograma.Size = New System.Drawing.Size(52, 22)
        Me.TextAntibiograma.TabIndex = 8
        '
        'TextPal
        '
        Me.TextPal.Location = New System.Drawing.Point(128, 143)
        Me.TextPal.Margin = New System.Windows.Forms.Padding(4)
        Me.TextPal.Name = "TextPal"
        Me.TextPal.Size = New System.Drawing.Size(52, 22)
        Me.TextPal.TabIndex = 9
        '
        'TextAmbiental
        '
        Me.TextAmbiental.Location = New System.Drawing.Point(348, 143)
        Me.TextAmbiental.Margin = New System.Windows.Forms.Padding(4)
        Me.TextAmbiental.Name = "TextAmbiental"
        Me.TextAmbiental.Size = New System.Drawing.Size(52, 22)
        Me.TextAmbiental.TabIndex = 14
        '
        'TextPatologia
        '
        Me.TextPatologia.Location = New System.Drawing.Point(348, 111)
        Me.TextPatologia.Margin = New System.Windows.Forms.Padding(4)
        Me.TextPatologia.Name = "TextPatologia"
        Me.TextPatologia.Size = New System.Drawing.Size(52, 22)
        Me.TextPatologia.TabIndex = 13
        '
        'TextSerologiaLeucosis
        '
        Me.TextSerologiaLeucosis.Location = New System.Drawing.Point(348, 79)
        Me.TextSerologiaLeucosis.Margin = New System.Windows.Forms.Padding(4)
        Me.TextSerologiaLeucosis.Name = "TextSerologiaLeucosis"
        Me.TextSerologiaLeucosis.Size = New System.Drawing.Size(52, 22)
        Me.TextSerologiaLeucosis.TabIndex = 12
        '
        'TextProductos
        '
        Me.TextProductos.Location = New System.Drawing.Point(348, 47)
        Me.TextProductos.Margin = New System.Windows.Forms.Padding(4)
        Me.TextProductos.Name = "TextProductos"
        Me.TextProductos.Size = New System.Drawing.Size(52, 22)
        Me.TextProductos.TabIndex = 11
        '
        'TextParasitologia
        '
        Me.TextParasitologia.Location = New System.Drawing.Point(348, 15)
        Me.TextParasitologia.Margin = New System.Windows.Forms.Padding(4)
        Me.TextParasitologia.Name = "TextParasitologia"
        Me.TextParasitologia.Size = New System.Drawing.Size(52, 22)
        Me.TextParasitologia.TabIndex = 10
        '
        'TextOtros
        '
        Me.TextOtros.Location = New System.Drawing.Point(572, 76)
        Me.TextOtros.Margin = New System.Windows.Forms.Padding(4)
        Me.TextOtros.Name = "TextOtros"
        Me.TextOtros.Size = New System.Drawing.Size(52, 22)
        Me.TextOtros.TabIndex = 17
        '
        'TextAgroNutricion
        '
        Me.TextAgroNutricion.Location = New System.Drawing.Point(572, 44)
        Me.TextAgroNutricion.Margin = New System.Windows.Forms.Padding(4)
        Me.TextAgroNutricion.Name = "TextAgroNutricion"
        Me.TextAgroNutricion.Size = New System.Drawing.Size(52, 22)
        Me.TextAgroNutricion.TabIndex = 16
        '
        'TextLactometros
        '
        Me.TextLactometros.Location = New System.Drawing.Point(572, 10)
        Me.TextLactometros.Margin = New System.Windows.Forms.Padding(4)
        Me.TextLactometros.Name = "TextLactometros"
        Me.TextLactometros.Size = New System.Drawing.Size(52, 22)
        Me.TextLactometros.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 17)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Control lechero"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 50)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 17)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Calidad de leche"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 82)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 17)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Agua"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 114)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 17)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Antibiograma"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 146)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 17)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "PAL"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(215, 18)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 17)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Parasitología"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(215, 50)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 17)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Productos"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(215, 82)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(128, 17)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Serología Leucosis"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(215, 114)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 17)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Patología"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(215, 146)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 17)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Ambiental"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(425, 16)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 17)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "Lactómetros"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(425, 48)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 17)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "Nutrición"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(425, 82)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(102, 17)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "Otros servicios"
        '
        'TextAgroSuelos
        '
        Me.TextAgroSuelos.Location = New System.Drawing.Point(572, 108)
        Me.TextAgroSuelos.Margin = New System.Windows.Forms.Padding(4)
        Me.TextAgroSuelos.Name = "TextAgroSuelos"
        Me.TextAgroSuelos.Size = New System.Drawing.Size(52, 22)
        Me.TextAgroSuelos.TabIndex = 31
        '
        'TextBrucelosisLeche
        '
        Me.TextBrucelosisLeche.Location = New System.Drawing.Point(837, 138)
        Me.TextBrucelosisLeche.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBrucelosisLeche.Name = "TextBrucelosisLeche"
        Me.TextBrucelosisLeche.Size = New System.Drawing.Size(52, 22)
        Me.TextBrucelosisLeche.TabIndex = 32
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(425, 112)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(51, 17)
        Me.Label14.TabIndex = 33
        Me.Label14.Text = "Suelos"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(665, 142)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(111, 17)
        Me.Label15.TabIndex = 34
        Me.Label15.Text = "Brucelosis leche"
        '
        'TextSerologiaBrucelosis
        '
        Me.TextSerologiaBrucelosis.Location = New System.Drawing.Point(572, 140)
        Me.TextSerologiaBrucelosis.Margin = New System.Windows.Forms.Padding(4)
        Me.TextSerologiaBrucelosis.Name = "TextSerologiaBrucelosis"
        Me.TextSerologiaBrucelosis.Size = New System.Drawing.Size(52, 22)
        Me.TextSerologiaBrucelosis.TabIndex = 35
        '
        'TextSerologiaOtros
        '
        Me.TextSerologiaOtros.Location = New System.Drawing.Point(837, 10)
        Me.TextSerologiaOtros.Margin = New System.Windows.Forms.Padding(4)
        Me.TextSerologiaOtros.Name = "TextSerologiaOtros"
        Me.TextSerologiaOtros.Size = New System.Drawing.Size(52, 22)
        Me.TextSerologiaOtros.TabIndex = 36
        '
        'TextSPSalmonellaListeria
        '
        Me.TextSPSalmonellaListeria.Location = New System.Drawing.Point(837, 42)
        Me.TextSPSalmonellaListeria.Margin = New System.Windows.Forms.Padding(4)
        Me.TextSPSalmonellaListeria.Name = "TextSPSalmonellaListeria"
        Me.TextSPSalmonellaListeria.Size = New System.Drawing.Size(52, 22)
        Me.TextSPSalmonellaListeria.TabIndex = 37
        '
        'TextSPMohosLevaduras
        '
        Me.TextSPMohosLevaduras.Location = New System.Drawing.Point(837, 74)
        Me.TextSPMohosLevaduras.Margin = New System.Windows.Forms.Padding(4)
        Me.TextSPMohosLevaduras.Name = "TextSPMohosLevaduras"
        Me.TextSPMohosLevaduras.Size = New System.Drawing.Size(52, 22)
        Me.TextSPMohosLevaduras.TabIndex = 38
        '
        'TextEsporulados
        '
        Me.TextEsporulados.Location = New System.Drawing.Point(837, 106)
        Me.TextEsporulados.Margin = New System.Windows.Forms.Padding(4)
        Me.TextEsporulados.Name = "TextEsporulados"
        Me.TextEsporulados.Size = New System.Drawing.Size(52, 22)
        Me.TextEsporulados.TabIndex = 39
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(425, 146)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(137, 17)
        Me.Label16.TabIndex = 41
        Me.Label16.Text = "Serología Brucelosis"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(665, 15)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(104, 17)
        Me.Label17.TabIndex = 42
        Me.Label17.Text = "Serología otros"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(665, 47)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(167, 17)
        Me.Label18.TabIndex = 43
        Me.Label18.Text = "(SP) Salmonella / Listeria"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(665, 80)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(159, 17)
        Me.Label19.TabIndex = 44
        Me.Label19.Text = "(SP) Mohos y levaduras"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(665, 110)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(87, 17)
        Me.Label20.TabIndex = 45
        Me.Label20.Text = "Esporulados"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(665, 174)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(67, 17)
        Me.Label21.TabIndex = 47
        Me.Label21.Text = "Efluentes"
        '
        'TextEfluentes
        '
        Me.TextEfluentes.Location = New System.Drawing.Point(837, 170)
        Me.TextEfluentes.Margin = New System.Windows.Forms.Padding(4)
        Me.TextEfluentes.Name = "TextEfluentes"
        Me.TextEfluentes.Size = New System.Drawing.Size(52, 22)
        Me.TextEfluentes.TabIndex = 46
        '
        'FormInformesPendientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1195, 695)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.TextEfluentes)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.TextEsporulados)
        Me.Controls.Add(Me.TextSPMohosLevaduras)
        Me.Controls.Add(Me.TextSPSalmonellaListeria)
        Me.Controls.Add(Me.TextSerologiaOtros)
        Me.Controls.Add(Me.TextSerologiaBrucelosis)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TextBrucelosisLeche)
        Me.Controls.Add(Me.TextAgroSuelos)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextOtros)
        Me.Controls.Add(Me.TextAgroNutricion)
        Me.Controls.Add(Me.TextLactometros)
        Me.Controls.Add(Me.TextAmbiental)
        Me.Controls.Add(Me.TextPatologia)
        Me.Controls.Add(Me.TextSerologiaLeucosis)
        Me.Controls.Add(Me.TextProductos)
        Me.Controls.Add(Me.TextParasitologia)
        Me.Controls.Add(Me.TextPal)
        Me.Controls.Add(Me.TextAntibiograma)
        Me.Controls.Add(Me.TextAgua)
        Me.Controls.Add(Me.TextCalidad)
        Me.Controls.Add(Me.TextControl)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.DateSolicitud)
        Me.Controls.Add(Me.DateHoy)
        Me.Controls.Add(Me.ButtonImprimir)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormInformesPendientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informes Pendientes"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonImprimir As System.Windows.Forms.Button
    Friend WithEvents DateHoy As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateSolicitud As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents TextControl As System.Windows.Forms.TextBox
    Friend WithEvents TextCalidad As System.Windows.Forms.TextBox
    Friend WithEvents TextAgua As System.Windows.Forms.TextBox
    Friend WithEvents TextAntibiograma As System.Windows.Forms.TextBox
    Friend WithEvents TextPal As System.Windows.Forms.TextBox
    Friend WithEvents TextAmbiental As System.Windows.Forms.TextBox
    Friend WithEvents TextPatologia As System.Windows.Forms.TextBox
    Friend WithEvents TextSerologiaLeucosis As System.Windows.Forms.TextBox
    Friend WithEvents TextProductos As System.Windows.Forms.TextBox
    Friend WithEvents TextParasitologia As System.Windows.Forms.TextBox
    Friend WithEvents TextOtros As System.Windows.Forms.TextBox
    Friend WithEvents TextAgroNutricion As System.Windows.Forms.TextBox
    Friend WithEvents TextLactometros As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextAgroSuelos As System.Windows.Forms.TextBox
    Friend WithEvents TextBrucelosisLeche As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TextSerologiaBrucelosis As System.Windows.Forms.TextBox
    Friend WithEvents TextSerologiaOtros As System.Windows.Forms.TextBox
    Friend WithEvents TextSPSalmonellaListeria As System.Windows.Forms.TextBox
    Friend WithEvents TextSPMohosLevaduras As System.Windows.Forms.TextBox
    Friend WithEvents TextEsporulados As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TextEfluentes As System.Windows.Forms.TextBox
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Informe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ficha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Muestras As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
