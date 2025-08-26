<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormControldeInformes
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
        Me.DateDesde = New System.Windows.Forms.DateTimePicker()
        Me.DateHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ButtonBuscarInformes = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaControl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ficha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sinavele = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Muestra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Subtipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Resultado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Coincide = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.OM = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.NC = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Controlador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VerInforme = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Controlada = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.InfConTecnico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InfConNomTec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ButtonVerControles = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbxTipoInfome = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbxControladores = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ButtonBuscar = New System.Windows.Forms.Button()
        Me.CantInformes = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DateFecha = New System.Windows.Forms.DateTimePicker()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.CantInformes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DateDesde
        '
        Me.DateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDesde.Location = New System.Drawing.Point(8, 44)
        Me.DateDesde.Margin = New System.Windows.Forms.Padding(4)
        Me.DateDesde.Name = "DateDesde"
        Me.DateDesde.Size = New System.Drawing.Size(128, 22)
        Me.DateDesde.TabIndex = 0
        '
        'DateHasta
        '
        Me.DateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateHasta.Location = New System.Drawing.Point(145, 44)
        Me.DateHasta.Margin = New System.Windows.Forms.Padding(4)
        Me.DateHasta.Name = "DateHasta"
        Me.DateHasta.Size = New System.Drawing.Size(128, 22)
        Me.DateHasta.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 25)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Desde"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(141, 25)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Hasta"
        '
        'ButtonBuscarInformes
        '
        Me.ButtonBuscarInformes.Location = New System.Drawing.Point(283, 44)
        Me.ButtonBuscarInformes.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonBuscarInformes.Name = "ButtonBuscarInformes"
        Me.ButtonBuscarInformes.Size = New System.Drawing.Size(131, 28)
        Me.ButtonBuscarInformes.TabIndex = 4
        Me.ButtonBuscarInformes.Text = "Buscar informes"
        Me.ButtonBuscarInformes.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.FechaControl, Me.Ficha, Me.Sinavele, Me.Fecha, Me.Muestra, Me.Tipo, Me.Subtipo, Me.Resultado, Me.Coincide, Me.OM, Me.NC, Me.Observaciones, Me.Controlador, Me.VerInforme, Me.Controlada, Me.InfConTecnico, Me.InfConNomTec})
        Me.DataGridView1.Location = New System.Drawing.Point(16, 215)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(1404, 398)
        Me.DataGridView1.TabIndex = 5
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'FechaControl
        '
        Me.FechaControl.HeaderText = "FechaControl"
        Me.FechaControl.Name = "FechaControl"
        Me.FechaControl.Visible = False
        '
        'Ficha
        '
        Me.Ficha.HeaderText = "Ficha"
        Me.Ficha.Name = "Ficha"
        Me.Ficha.Width = 75
        '
        'Sinavele
        '
        Me.Sinavele.HeaderText = "Sinavele"
        Me.Sinavele.Name = "Sinavele"
        Me.Sinavele.Width = 75
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 75
        '
        'Muestra
        '
        Me.Muestra.HeaderText = "Muestra"
        Me.Muestra.Name = "Muestra"
        '
        'Tipo
        '
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.Width = 120
        '
        'Subtipo
        '
        Me.Subtipo.HeaderText = "Subtipo"
        Me.Subtipo.Name = "Subtipo"
        Me.Subtipo.Width = 120
        '
        'Resultado
        '
        Me.Resultado.HeaderText = "Resultado"
        Me.Resultado.Name = "Resultado"
        Me.Resultado.Width = 57
        '
        'Coincide
        '
        Me.Coincide.HeaderText = "Coincide"
        Me.Coincide.Name = "Coincide"
        Me.Coincide.Width = 55
        '
        'OM
        '
        Me.OM.HeaderText = "OM"
        Me.OM.Name = "OM"
        Me.OM.Width = 30
        '
        'NC
        '
        Me.NC.HeaderText = "NC"
        Me.NC.Name = "NC"
        Me.NC.Width = 30
        '
        'Observaciones
        '
        Me.Observaciones.HeaderText = "Observaciones"
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.Width = 150
        '
        'Controlador
        '
        Me.Controlador.HeaderText = "Controlador"
        Me.Controlador.Name = "Controlador"
        Me.Controlador.Visible = False
        '
        'VerInforme
        '
        Me.VerInforme.HeaderText = "Ver Informe"
        Me.VerInforme.Name = "VerInforme"
        '
        'Controlada
        '
        Me.Controlada.HeaderText = "Controlada"
        Me.Controlada.Name = "Controlada"
        Me.Controlada.Width = 60
        '
        'InfConTecnico
        '
        Me.InfConTecnico.HeaderText = "Informe controlado"
        Me.InfConTecnico.Name = "InfConTecnico"
        '
        'InfConNomTec
        '
        Me.InfConNomTec.HeaderText = "Técnico"
        Me.InfConNomTec.Name = "InfConNomTec"
        '
        'ButtonVerControles
        '
        Me.ButtonVerControles.Location = New System.Drawing.Point(1108, 39)
        Me.ButtonVerControles.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonVerControles.Name = "ButtonVerControles"
        Me.ButtonVerControles.Size = New System.Drawing.Size(185, 28)
        Me.ButtonVerControles.TabIndex = 6
        Me.ButtonVerControles.Text = "Ver controles realizados"
        Me.ButtonVerControles.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbxTipoInfome)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cbxControladores)
        Me.GroupBox1.Controls.Add(Me.DateDesde)
        Me.GroupBox1.Controls.Add(Me.DateHasta)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ButtonBuscarInformes)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 5)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(419, 202)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Por rango de fechas"
        '
        'cbxTipoInfome
        '
        Me.cbxTipoInfome.FormattingEnabled = True
        Me.cbxTipoInfome.Location = New System.Drawing.Point(8, 162)
        Me.cbxTipoInfome.Name = "cbxTipoInfome"
        Me.cbxTipoInfome.Size = New System.Drawing.Size(263, 24)
        Me.cbxTipoInfome.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 141)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 17)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Tipo de Informe"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 17)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Controladores"
        '
        'cbxControladores
        '
        Me.cbxControladores.FormattingEnabled = True
        Me.cbxControladores.Location = New System.Drawing.Point(8, 96)
        Me.cbxControladores.Name = "cbxControladores"
        Me.cbxControladores.Size = New System.Drawing.Size(263, 24)
        Me.cbxControladores.TabIndex = 5
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ButtonBuscar)
        Me.GroupBox2.Controls.Add(Me.CantInformes)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.DateFecha)
        Me.GroupBox2.Location = New System.Drawing.Point(488, 5)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(379, 76)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Por día determinado"
        Me.GroupBox2.Visible = False
        '
        'ButtonBuscar
        '
        Me.ButtonBuscar.Location = New System.Drawing.Point(243, 43)
        Me.ButtonBuscar.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonBuscar.Name = "ButtonBuscar"
        Me.ButtonBuscar.Size = New System.Drawing.Size(128, 28)
        Me.ButtonBuscar.TabIndex = 3
        Me.ButtonBuscar.Text = "Buscar informes"
        Me.ButtonBuscar.UseVisualStyleBackColor = True
        '
        'CantInformes
        '
        Me.CantInformes.Location = New System.Drawing.Point(156, 46)
        Me.CantInformes.Margin = New System.Windows.Forms.Padding(4)
        Me.CantInformes.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.CantInformes.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.CantInformes.Name = "CantInformes"
        Me.CantInformes.Size = New System.Drawing.Size(56, 22)
        Me.CantInformes.TabIndex = 2
        Me.CantInformes.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(152, 26)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 17)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Informes"
        '
        'DateFecha
        '
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(8, 46)
        Me.DateFecha.Margin = New System.Windows.Forms.Padding(4)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(127, 22)
        Me.DateFecha.TabIndex = 0
        '
        'FormControldeInformes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1433, 628)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ButtonVerControles)
        Me.Controls.Add(Me.DataGridView1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormControldeInformes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Control de informes (RG.CC.32)"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.CantInformes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DateDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ButtonBuscarInformes As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonVerControles As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonBuscar As System.Windows.Forms.Button
    Friend WithEvents CantInformes As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaControl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ficha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sinavele As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Muestra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Subtipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Resultado As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Coincide As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents OM As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents NC As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Observaciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Controlador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VerInforme As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Controlada As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents InfConTecnico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InfConNomTec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cbxTipoInfome As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbxControladores As System.Windows.Forms.ComboBox
End Class
