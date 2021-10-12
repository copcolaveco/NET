<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormControlesRealizados
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
        Me.RadioTodos = New System.Windows.Forms.RadioButton()
        Me.RadioOM = New System.Windows.Forms.RadioButton()
        Me.RadioNC = New System.Windows.Forms.RadioButton()
        Me.ButtonListar = New System.Windows.Forms.Button()
        Me.TextCantidad = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaControl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ficha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Muestra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Subtipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Resultado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Coincide = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.OM = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.NC = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.CL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AGUA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SPROD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SER = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TOX = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PAR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BACT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bru = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DateDesde
        '
        Me.DateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDesde.Location = New System.Drawing.Point(21, 30)
        Me.DateDesde.Name = "DateDesde"
        Me.DateDesde.Size = New System.Drawing.Size(97, 20)
        Me.DateDesde.TabIndex = 0
        '
        'DateHasta
        '
        Me.DateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateHasta.Location = New System.Drawing.Point(124, 30)
        Me.DateHasta.Name = "DateHasta"
        Me.DateHasta.Size = New System.Drawing.Size(97, 20)
        Me.DateHasta.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Desde"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(121, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Hasta"
        '
        'RadioTodos
        '
        Me.RadioTodos.AutoSize = True
        Me.RadioTodos.Location = New System.Drawing.Point(21, 56)
        Me.RadioTodos.Name = "RadioTodos"
        Me.RadioTodos.Size = New System.Drawing.Size(55, 17)
        Me.RadioTodos.TabIndex = 4
        Me.RadioTodos.TabStop = True
        Me.RadioTodos.Text = "Todos"
        Me.RadioTodos.UseVisualStyleBackColor = True
        '
        'RadioOM
        '
        Me.RadioOM.AutoSize = True
        Me.RadioOM.Location = New System.Drawing.Point(21, 79)
        Me.RadioOM.Name = "RadioOM"
        Me.RadioOM.Size = New System.Drawing.Size(108, 17)
        Me.RadioOM.TabIndex = 5
        Me.RadioOM.TabStop = True
        Me.RadioOM.Text = "Opción de mejora"
        Me.RadioOM.UseVisualStyleBackColor = True
        '
        'RadioNC
        '
        Me.RadioNC.AutoSize = True
        Me.RadioNC.Location = New System.Drawing.Point(21, 102)
        Me.RadioNC.Name = "RadioNC"
        Me.RadioNC.Size = New System.Drawing.Size(100, 17)
        Me.RadioNC.TabIndex = 6
        Me.RadioNC.TabStop = True
        Me.RadioNC.Text = "No conformidad"
        Me.RadioNC.UseVisualStyleBackColor = True
        '
        'ButtonListar
        '
        Me.ButtonListar.Location = New System.Drawing.Point(146, 65)
        Me.ButtonListar.Name = "ButtonListar"
        Me.ButtonListar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonListar.TabIndex = 7
        Me.ButtonListar.Text = "Listar"
        Me.ButtonListar.UseVisualStyleBackColor = True
        '
        'TextCantidad
        '
        Me.TextCantidad.Location = New System.Drawing.Point(867, 485)
        Me.TextCantidad.Name = "TextCantidad"
        Me.TextCantidad.ReadOnly = True
        Me.TextCantidad.Size = New System.Drawing.Size(100, 20)
        Me.TextCantidad.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(755, 492)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Cantidad de informes"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.FechaControl, Me.Ficha, Me.Fecha, Me.Muestra, Me.Tipo, Me.Subtipo, Me.Resultado, Me.Coincide, Me.OM, Me.NC, Me.Observaciones})
        Me.DataGridView1.Location = New System.Drawing.Point(21, 134)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(946, 345)
        Me.DataGridView1.TabIndex = 11
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
        Me.Observaciones.Width = 350
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CL, Me.CAL, Me.AGUA, Me.SPROD, Me.SER, Me.PAL, Me.TOX, Me.PAR, Me.BACT, Me.NUT, Me.Sue, Me.Bru})
        Me.DataGridView2.Location = New System.Drawing.Point(240, 30)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.Size = New System.Drawing.Size(734, 72)
        Me.DataGridView2.TabIndex = 12
        '
        'CL
        '
        Me.CL.HeaderText = "CL"
        Me.CL.Name = "CL"
        Me.CL.Width = 60
        '
        'CAL
        '
        Me.CAL.HeaderText = "CAL"
        Me.CAL.Name = "CAL"
        Me.CAL.Width = 60
        '
        'AGUA
        '
        Me.AGUA.HeaderText = "AGUA"
        Me.AGUA.Name = "AGUA"
        Me.AGUA.Width = 60
        '
        'SPROD
        '
        Me.SPROD.HeaderText = "S. PROD."
        Me.SPROD.Name = "SPROD"
        Me.SPROD.Width = 60
        '
        'SER
        '
        Me.SER.HeaderText = "SER"
        Me.SER.Name = "SER"
        Me.SER.Width = 60
        '
        'PAL
        '
        Me.PAL.HeaderText = "PAL"
        Me.PAL.Name = "PAL"
        Me.PAL.Width = 60
        '
        'TOX
        '
        Me.TOX.HeaderText = "TOX."
        Me.TOX.Name = "TOX"
        Me.TOX.Width = 60
        '
        'PAR
        '
        Me.PAR.HeaderText = "PAR."
        Me.PAR.Name = "PAR"
        Me.PAR.Width = 60
        '
        'BACT
        '
        Me.BACT.HeaderText = "BACT."
        Me.BACT.Name = "BACT"
        Me.BACT.Width = 60
        '
        'NUT
        '
        Me.NUT.HeaderText = "NUT."
        Me.NUT.Name = "NUT"
        Me.NUT.Width = 60
        '
        'Sue
        '
        Me.Sue.HeaderText = "SUE."
        Me.Sue.Name = "Sue"
        Me.Sue.Width = 60
        '
        'Bru
        '
        Me.Bru.HeaderText = "BRU."
        Me.Bru.Name = "Bru"
        Me.Bru.Width = 60
        '
        'FormControlesRealizados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(986, 516)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextCantidad)
        Me.Controls.Add(Me.ButtonListar)
        Me.Controls.Add(Me.RadioNC)
        Me.Controls.Add(Me.RadioOM)
        Me.Controls.Add(Me.RadioTodos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateHasta)
        Me.Controls.Add(Me.DateDesde)
        Me.Name = "FormControlesRealizados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informes de controles realizados"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DateDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RadioTodos As System.Windows.Forms.RadioButton
    Friend WithEvents RadioOM As System.Windows.Forms.RadioButton
    Friend WithEvents RadioNC As System.Windows.Forms.RadioButton
    Friend WithEvents ButtonListar As System.Windows.Forms.Button
    Friend WithEvents TextCantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaControl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ficha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Muestra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Subtipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Resultado As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Coincide As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents OM As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents NC As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Observaciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents CL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AGUA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SPROD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SER As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TOX As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PAR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BACT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bru As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
