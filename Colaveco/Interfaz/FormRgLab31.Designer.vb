<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRgLab31
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
        Me.components = New System.ComponentModel.Container()
        Me.TextId = New System.Windows.Forms.TextBox()
        Me.DateFecha = New System.Windows.Forms.DateTimePicker()
        Me.TextHora = New System.Windows.Forms.TextBox()
        Me.TextFicha = New System.Windows.Forms.TextBox()
        Me.TextCantidad = New System.Windows.Forms.TextBox()
        Me.ComboAnalisis = New System.Windows.Forms.ComboBox()
        Me.ComboOperador = New System.Windows.Forms.ComboBox()
        Me.TextTemperatura = New System.Windows.Forms.TextBox()
        Me.TextHumedad = New System.Windows.Forms.TextBox()
        Me.ComboEliminado = New System.Windows.Forms.ComboBox()
        Me.TextObservaciones = New System.Windows.Forms.TextBox()
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
        Me.ButtonNuevo = New System.Windows.Forms.Button()
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.ButtonEliminar = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ficha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.CheckCaseina = New System.Windows.Forms.CheckBox()
        Me.CheckCrioscopo = New System.Windows.Forms.CheckBox()
        Me.CheckUrea2 = New System.Windows.Forms.CheckBox()
        Me.CheckInhibidores = New System.Windows.Forms.CheckBox()
        Me.CheckCrioscopia = New System.Windows.Forms.CheckBox()
        Me.CheckComposicion2 = New System.Windows.Forms.CheckBox()
        Me.CheckRC2 = New System.Windows.Forms.CheckBox()
        Me.CheckRB = New System.Windows.Forms.CheckBox()
        Me.CheckEsporulados = New System.Windows.Forms.CheckBox()
        Me.CheckPsicrotrofos = New System.Windows.Forms.CheckBox()
        Me.CheckTermofilos = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckUrea = New System.Windows.Forms.CheckBox()
        Me.CheckComposicion = New System.Windows.Forms.CheckBox()
        Me.CheckRC = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ComboEquipo = New System.Windows.Forms.ComboBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label13 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(135, 54)
        Me.TextId.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(99, 22)
        Me.TextId.TabIndex = 0
        '
        'DateFecha
        '
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(135, 86)
        Me.DateFecha.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(132, 22)
        Me.DateFecha.TabIndex = 1
        '
        'TextHora
        '
        Me.TextHora.Location = New System.Drawing.Point(135, 118)
        Me.TextHora.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextHora.Name = "TextHora"
        Me.TextHora.Size = New System.Drawing.Size(99, 22)
        Me.TextHora.TabIndex = 2
        '
        'TextFicha
        '
        Me.TextFicha.Location = New System.Drawing.Point(135, 183)
        Me.TextFicha.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextFicha.Name = "TextFicha"
        Me.TextFicha.Size = New System.Drawing.Size(99, 22)
        Me.TextFicha.TabIndex = 3
        '
        'TextCantidad
        '
        Me.TextCantidad.Location = New System.Drawing.Point(135, 215)
        Me.TextCantidad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextCantidad.Name = "TextCantidad"
        Me.TextCantidad.Size = New System.Drawing.Size(99, 22)
        Me.TextCantidad.TabIndex = 4
        '
        'ComboAnalisis
        '
        Me.ComboAnalisis.FormattingEnabled = True
        Me.ComboAnalisis.Location = New System.Drawing.Point(135, 247)
        Me.ComboAnalisis.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboAnalisis.Name = "ComboAnalisis"
        Me.ComboAnalisis.Size = New System.Drawing.Size(243, 24)
        Me.ComboAnalisis.TabIndex = 5
        '
        'ComboOperador
        '
        Me.ComboOperador.FormattingEnabled = True
        Me.ComboOperador.Location = New System.Drawing.Point(135, 502)
        Me.ComboOperador.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboOperador.Name = "ComboOperador"
        Me.ComboOperador.Size = New System.Drawing.Size(243, 24)
        Me.ComboOperador.TabIndex = 6
        '
        'TextTemperatura
        '
        Me.TextTemperatura.Location = New System.Drawing.Point(135, 535)
        Me.TextTemperatura.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextTemperatura.Name = "TextTemperatura"
        Me.TextTemperatura.Size = New System.Drawing.Size(99, 22)
        Me.TextTemperatura.TabIndex = 7
        '
        'TextHumedad
        '
        Me.TextHumedad.Location = New System.Drawing.Point(135, 567)
        Me.TextHumedad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextHumedad.Name = "TextHumedad"
        Me.TextHumedad.Size = New System.Drawing.Size(99, 22)
        Me.TextHumedad.TabIndex = 8
        '
        'ComboEliminado
        '
        Me.ComboEliminado.FormattingEnabled = True
        Me.ComboEliminado.Location = New System.Drawing.Point(135, 599)
        Me.ComboEliminado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboEliminado.Name = "ComboEliminado"
        Me.ComboEliminado.Size = New System.Drawing.Size(243, 24)
        Me.ComboEliminado.TabIndex = 9
        '
        'TextObservaciones
        '
        Me.TextObservaciones.Location = New System.Drawing.Point(135, 633)
        Me.TextObservaciones.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextObservaciones.Multiline = True
        Me.TextObservaciones.Name = "TextObservaciones"
        Me.TextObservaciones.Size = New System.Drawing.Size(243, 159)
        Me.TextObservaciones.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 58)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 17)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 94)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 17)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Fecha"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 122)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 17)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Hora"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 187)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 17)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Ficha"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 219)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 17)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Cantidad"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 251)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 17)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Analisis"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(23, 506)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 17)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Operador"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(23, 539)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(108, 17)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Temperatura ºC"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(23, 571)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 17)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Humedad %"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(23, 603)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(105, 17)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Eliminadas por:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(23, 636)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(103, 17)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Observaciones"
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Location = New System.Drawing.Point(63, 814)
        Me.ButtonNuevo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(100, 28)
        Me.ButtonNuevo.TabIndex = 22
        Me.ButtonNuevo.Text = "Nuevo"
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(171, 814)
        Me.ButtonGuardar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(100, 28)
        Me.ButtonGuardar.TabIndex = 23
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(279, 814)
        Me.ButtonEliminar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(100, 28)
        Me.ButtonEliminar.TabIndex = 24
        Me.ButtonEliminar.Text = "Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Fecha, Me.Ficha})
        Me.DataGridView1.Location = New System.Drawing.Point(600, 54)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(276, 705)
        Me.DataGridView1.TabIndex = 25
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        '
        'Ficha
        '
        Me.Ficha.HeaderText = "Ficha"
        Me.Ficha.Name = "Ficha"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.CheckCaseina)
        Me.GroupBox7.Controls.Add(Me.CheckCrioscopo)
        Me.GroupBox7.Controls.Add(Me.CheckUrea2)
        Me.GroupBox7.Controls.Add(Me.CheckInhibidores)
        Me.GroupBox7.Controls.Add(Me.CheckCrioscopia)
        Me.GroupBox7.Controls.Add(Me.CheckComposicion2)
        Me.GroupBox7.Controls.Add(Me.CheckRC2)
        Me.GroupBox7.Controls.Add(Me.CheckRB)
        Me.GroupBox7.Controls.Add(Me.CheckEsporulados)
        Me.GroupBox7.Controls.Add(Me.CheckPsicrotrofos)
        Me.GroupBox7.Controls.Add(Me.CheckTermofilos)
        Me.GroupBox7.Location = New System.Drawing.Point(204, 281)
        Me.GroupBox7.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox7.Size = New System.Drawing.Size(388, 208)
        Me.GroupBox7.TabIndex = 42
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Calidad"
        '
        'CheckCaseina
        '
        Me.CheckCaseina.AutoSize = True
        Me.CheckCaseina.Location = New System.Drawing.Point(212, 145)
        Me.CheckCaseina.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckCaseina.Name = "CheckCaseina"
        Me.CheckCaseina.Size = New System.Drawing.Size(81, 21)
        Me.CheckCaseina.TabIndex = 10
        Me.CheckCaseina.Text = "Caseína"
        Me.CheckCaseina.UseVisualStyleBackColor = True
        '
        'CheckCrioscopo
        '
        Me.CheckCrioscopo.AutoSize = True
        Me.CheckCrioscopo.Location = New System.Drawing.Point(15, 148)
        Me.CheckCrioscopo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckCrioscopo.Name = "CheckCrioscopo"
        Me.CheckCrioscopo.Size = New System.Drawing.Size(173, 21)
        Me.CheckCrioscopo.TabIndex = 4
        Me.CheckCrioscopo.Text = "Crioscopía (Crióscopo)"
        Me.CheckCrioscopo.UseVisualStyleBackColor = True
        '
        'CheckUrea2
        '
        Me.CheckUrea2.AutoSize = True
        Me.CheckUrea2.Location = New System.Drawing.Point(212, 63)
        Me.CheckUrea2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckUrea2.Name = "CheckUrea2"
        Me.CheckUrea2.Size = New System.Drawing.Size(61, 21)
        Me.CheckUrea2.TabIndex = 7
        Me.CheckUrea2.Text = "Urea"
        Me.CheckUrea2.UseVisualStyleBackColor = True
        '
        'CheckInhibidores
        '
        Me.CheckInhibidores.AutoSize = True
        Me.CheckInhibidores.Location = New System.Drawing.Point(15, 176)
        Me.CheckInhibidores.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckInhibidores.Name = "CheckInhibidores"
        Me.CheckInhibidores.Size = New System.Drawing.Size(99, 21)
        Me.CheckInhibidores.TabIndex = 5
        Me.CheckInhibidores.Text = "Inhibidores"
        Me.CheckInhibidores.UseVisualStyleBackColor = True
        '
        'CheckCrioscopia
        '
        Me.CheckCrioscopia.AutoSize = True
        Me.CheckCrioscopia.Location = New System.Drawing.Point(15, 119)
        Me.CheckCrioscopia.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckCrioscopia.Name = "CheckCrioscopia"
        Me.CheckCrioscopia.Size = New System.Drawing.Size(143, 21)
        Me.CheckCrioscopia.TabIndex = 3
        Me.CheckCrioscopia.Text = "Crioscopía (Delta)"
        Me.CheckCrioscopia.UseVisualStyleBackColor = True
        '
        'CheckComposicion2
        '
        Me.CheckComposicion2.AutoSize = True
        Me.CheckComposicion2.Location = New System.Drawing.Point(15, 91)
        Me.CheckComposicion2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckComposicion2.Name = "CheckComposicion2"
        Me.CheckComposicion2.Size = New System.Drawing.Size(110, 21)
        Me.CheckComposicion2.TabIndex = 2
        Me.CheckComposicion2.Text = "Composición"
        Me.CheckComposicion2.UseVisualStyleBackColor = True
        '
        'CheckRC2
        '
        Me.CheckRC2.AutoSize = True
        Me.CheckRC2.Location = New System.Drawing.Point(15, 63)
        Me.CheckRC2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckRC2.Name = "CheckRC2"
        Me.CheckRC2.Size = New System.Drawing.Size(49, 21)
        Me.CheckRC2.TabIndex = 1
        Me.CheckRC2.Text = "RC"
        Me.CheckRC2.UseVisualStyleBackColor = True
        '
        'CheckRB
        '
        Me.CheckRB.AutoSize = True
        Me.CheckRB.Location = New System.Drawing.Point(15, 34)
        Me.CheckRB.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckRB.Name = "CheckRB"
        Me.CheckRB.Size = New System.Drawing.Size(49, 21)
        Me.CheckRB.TabIndex = 1
        Me.CheckRB.Text = "RB"
        Me.CheckRB.UseVisualStyleBackColor = True
        '
        'CheckEsporulados
        '
        Me.CheckEsporulados.AutoSize = True
        Me.CheckEsporulados.Location = New System.Drawing.Point(212, 34)
        Me.CheckEsporulados.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckEsporulados.Name = "CheckEsporulados"
        Me.CheckEsporulados.Size = New System.Drawing.Size(173, 21)
        Me.CheckEsporulados.TabIndex = 6
        Me.CheckEsporulados.Text = "Espor. Anaer. mesófilo"
        Me.CheckEsporulados.UseVisualStyleBackColor = True
        '
        'CheckPsicrotrofos
        '
        Me.CheckPsicrotrofos.AutoSize = True
        Me.CheckPsicrotrofos.Location = New System.Drawing.Point(212, 119)
        Me.CheckPsicrotrofos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckPsicrotrofos.Name = "CheckPsicrotrofos"
        Me.CheckPsicrotrofos.Size = New System.Drawing.Size(105, 21)
        Me.CheckPsicrotrofos.TabIndex = 9
        Me.CheckPsicrotrofos.Text = "Psicrotrofos"
        Me.CheckPsicrotrofos.UseVisualStyleBackColor = True
        '
        'CheckTermofilos
        '
        Me.CheckTermofilos.AutoSize = True
        Me.CheckTermofilos.Location = New System.Drawing.Point(212, 91)
        Me.CheckTermofilos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckTermofilos.Name = "CheckTermofilos"
        Me.CheckTermofilos.Size = New System.Drawing.Size(96, 21)
        Me.CheckTermofilos.TabIndex = 8
        Me.CheckTermofilos.Text = "Termofilos"
        Me.CheckTermofilos.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckUrea)
        Me.GroupBox1.Controls.Add(Me.CheckComposicion)
        Me.GroupBox1.Controls.Add(Me.CheckRC)
        Me.GroupBox1.Location = New System.Drawing.Point(27, 281)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(157, 117)
        Me.GroupBox1.TabIndex = 43
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Control"
        '
        'CheckUrea
        '
        Me.CheckUrea.AutoSize = True
        Me.CheckUrea.Location = New System.Drawing.Point(15, 80)
        Me.CheckUrea.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckUrea.Name = "CheckUrea"
        Me.CheckUrea.Size = New System.Drawing.Size(61, 21)
        Me.CheckUrea.TabIndex = 7
        Me.CheckUrea.Text = "Urea"
        Me.CheckUrea.UseVisualStyleBackColor = True
        '
        'CheckComposicion
        '
        Me.CheckComposicion.AutoSize = True
        Me.CheckComposicion.Location = New System.Drawing.Point(15, 52)
        Me.CheckComposicion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckComposicion.Name = "CheckComposicion"
        Me.CheckComposicion.Size = New System.Drawing.Size(110, 21)
        Me.CheckComposicion.TabIndex = 2
        Me.CheckComposicion.Text = "Composición"
        Me.CheckComposicion.UseVisualStyleBackColor = True
        '
        'CheckRC
        '
        Me.CheckRC.AutoSize = True
        Me.CheckRC.Location = New System.Drawing.Point(15, 23)
        Me.CheckRC.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckRC.Name = "CheckRC"
        Me.CheckRC.Size = New System.Drawing.Size(49, 21)
        Me.CheckRC.TabIndex = 1
        Me.CheckRC.Text = "RC"
        Me.CheckRC.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(25, 154)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 17)
        Me.Label12.TabIndex = 44
        Me.Label12.Text = "Equipo"
        '
        'ComboEquipo
        '
        Me.ComboEquipo.FormattingEnabled = True
        Me.ComboEquipo.Items.AddRange(New Object() {"Bentley", "Bentley 600", "Delta 600"})
        Me.ComboEquipo.Location = New System.Drawing.Point(135, 150)
        Me.ComboEquipo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboEquipo.Name = "ComboEquipo"
        Me.ComboEquipo.Size = New System.Drawing.Size(160, 24)
        Me.ComboEquipo.TabIndex = 45
        '
        'Timer1
        '
        Me.Timer1.Interval = 60000
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(16, 11)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(673, 25)
        Me.Label13.TabIndex = 46
        Me.Label13.Text = "Verificación del pedido del cliente, por parte del analista, en calidad de leche." & _
    ""
        '
        'FormRgLab31
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(889, 847)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.ComboEquipo)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ButtonNuevo)
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
        Me.Controls.Add(Me.TextObservaciones)
        Me.Controls.Add(Me.ComboEliminado)
        Me.Controls.Add(Me.TextHumedad)
        Me.Controls.Add(Me.TextTemperatura)
        Me.Controls.Add(Me.ComboOperador)
        Me.Controls.Add(Me.ComboAnalisis)
        Me.Controls.Add(Me.TextCantidad)
        Me.Controls.Add(Me.TextFicha)
        Me.Controls.Add(Me.TextHora)
        Me.Controls.Add(Me.DateFecha)
        Me.Controls.Add(Me.TextId)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FormRgLab31"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RGLAB 31"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextHora As System.Windows.Forms.TextBox
    Friend WithEvents TextFicha As System.Windows.Forms.TextBox
    Friend WithEvents TextCantidad As System.Windows.Forms.TextBox
    Friend WithEvents ComboAnalisis As System.Windows.Forms.ComboBox
    Friend WithEvents ComboOperador As System.Windows.Forms.ComboBox
    Friend WithEvents TextTemperatura As System.Windows.Forms.TextBox
    Friend WithEvents TextHumedad As System.Windows.Forms.TextBox
    Friend WithEvents ComboEliminado As System.Windows.Forms.ComboBox
    Friend WithEvents TextObservaciones As System.Windows.Forms.TextBox
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
    Friend WithEvents ButtonNuevo As System.Windows.Forms.Button
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ficha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckCaseina As System.Windows.Forms.CheckBox
    Friend WithEvents CheckCrioscopo As System.Windows.Forms.CheckBox
    Friend WithEvents CheckUrea2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckInhibidores As System.Windows.Forms.CheckBox
    Friend WithEvents CheckCrioscopia As System.Windows.Forms.CheckBox
    Friend WithEvents CheckComposicion2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckRC2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckRB As System.Windows.Forms.CheckBox
    Friend WithEvents CheckEsporulados As System.Windows.Forms.CheckBox
    Friend WithEvents CheckPsicrotrofos As System.Windows.Forms.CheckBox
    Friend WithEvents CheckTermofilos As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckUrea As System.Windows.Forms.CheckBox
    Friend WithEvents CheckComposicion As System.Windows.Forms.CheckBox
    Friend WithEvents CheckRC As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ComboEquipo As System.Windows.Forms.ComboBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
