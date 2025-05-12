<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBuscarSolicitud
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBuscarSolicitud))
        Me.Textficha = New System.Windows.Forms.TextBox()
        Me.TextIdProductor = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonBuscarProductor = New System.Windows.Forms.Button()
        Me.TextProductor = New System.Windows.Forms.TextBox()
        Me.DateTimeHasta = New System.Windows.Forms.DateTimePicker()
        Me.DateTimeDesde = New System.Windows.Forms.DateTimePicker()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Ficha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Muestras = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NoAptas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Analisis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ObsInternas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoMuestra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pagook = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Seleccionar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Excel = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.cbxTipoInforme = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Textficha
        '
        Me.Textficha.Location = New System.Drawing.Point(165, 38)
        Me.Textficha.Margin = New System.Windows.Forms.Padding(4)
        Me.Textficha.Name = "Textficha"
        Me.Textficha.Size = New System.Drawing.Size(75, 22)
        Me.Textficha.TabIndex = 4
        '
        'TextIdProductor
        '
        Me.TextIdProductor.Location = New System.Drawing.Point(165, 70)
        Me.TextIdProductor.Margin = New System.Windows.Forms.Padding(4)
        Me.TextIdProductor.Name = "TextIdProductor"
        Me.TextIdProductor.Size = New System.Drawing.Size(75, 22)
        Me.TextIdProductor.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 11)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 17)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Buscar solicitud por:"
        '
        'ButtonBuscarProductor
        '
        Me.ButtonBuscarProductor.Location = New System.Drawing.Point(248, 70)
        Me.ButtonBuscarProductor.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonBuscarProductor.Name = "ButtonBuscarProductor"
        Me.ButtonBuscarProductor.Size = New System.Drawing.Size(28, 23)
        Me.ButtonBuscarProductor.TabIndex = 7
        Me.ButtonBuscarProductor.Text = "^"
        Me.ButtonBuscarProductor.UseVisualStyleBackColor = True
        '
        'TextProductor
        '
        Me.TextProductor.Location = New System.Drawing.Point(294, 73)
        Me.TextProductor.Margin = New System.Windows.Forms.Padding(4)
        Me.TextProductor.Name = "TextProductor"
        Me.TextProductor.Size = New System.Drawing.Size(244, 22)
        Me.TextProductor.TabIndex = 8
        '
        'DateTimeHasta
        '
        Me.DateTimeHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimeHasta.Location = New System.Drawing.Point(344, 103)
        Me.DateTimeHasta.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimeHasta.Name = "DateTimeHasta"
        Me.DateTimeHasta.Size = New System.Drawing.Size(194, 22)
        Me.DateTimeHasta.TabIndex = 9
        '
        'DateTimeDesde
        '
        Me.DateTimeDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimeDesde.Location = New System.Drawing.Point(165, 104)
        Me.DateTimeDesde.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimeDesde.Name = "DateTimeDesde"
        Me.DateTimeDesde.Size = New System.Drawing.Size(171, 22)
        Me.DateTimeDesde.TabIndex = 10
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1331, 103)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(194, 28)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "Buscar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Ficha, Me.Fecha, Me.Muestras, Me.NoAptas, Me.Analisis, Me.Cliente, Me.Observaciones, Me.Estado, Me.Pago, Me.ObsInternas, Me.TipoMuestra, Me.Pagook, Me.Seleccionar, Me.Excel})
        Me.DataGridView1.Location = New System.Drawing.Point(19, 180)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(1605, 468)
        Me.DataGridView1.TabIndex = 14
        '
        'Ficha
        '
        Me.Ficha.HeaderText = "Ficha"
        Me.Ficha.Name = "Ficha"
        Me.Ficha.Width = 70
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 70
        '
        'Muestras
        '
        Me.Muestras.HeaderText = "Muestras"
        Me.Muestras.Name = "Muestras"
        Me.Muestras.Width = 60
        '
        'NoAptas
        '
        Me.NoAptas.HeaderText = "N/A"
        Me.NoAptas.Name = "NoAptas"
        Me.NoAptas.Width = 50
        '
        'Analisis
        '
        Me.Analisis.HeaderText = "Análisis"
        Me.Analisis.Name = "Analisis"
        Me.Analisis.Width = 150
        '
        'Cliente
        '
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.Width = 200
        '
        'Observaciones
        '
        Me.Observaciones.HeaderText = "Observaciones"
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.Width = 200
        '
        'Estado
        '
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Name = "Estado"
        '
        'Pago
        '
        Me.Pago.HeaderText = "Pago"
        Me.Pago.Name = "Pago"
        Me.Pago.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Pago.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Pago.Width = 50
        '
        'ObsInternas
        '
        Me.ObsInternas.HeaderText = "ObsInternas"
        Me.ObsInternas.Name = "ObsInternas"
        Me.ObsInternas.ReadOnly = True
        Me.ObsInternas.Width = 50
        '
        'TipoMuestra
        '
        Me.TipoMuestra.HeaderText = "TipoMuestra"
        Me.TipoMuestra.Name = "TipoMuestra"
        Me.TipoMuestra.ReadOnly = True
        Me.TipoMuestra.Width = 50
        '
        'Pagook
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pagook.DefaultCellStyle = DataGridViewCellStyle1
        Me.Pagook.HeaderText = ""
        Me.Pagook.Name = "Pagook"
        Me.Pagook.Text = "Pago Ok"
        Me.Pagook.UseColumnTextForButtonValue = True
        Me.Pagook.Width = 50
        '
        'Seleccionar
        '
        Me.Seleccionar.HeaderText = ""
        Me.Seleccionar.Name = "Seleccionar"
        Me.Seleccionar.Text = "Seleccionar"
        Me.Seleccionar.UseColumnTextForButtonValue = True
        '
        'Excel
        '
        Me.Excel.HeaderText = ""
        Me.Excel.Name = "Excel"
        Me.Excel.Text = "Excel/Pdf"
        Me.Excel.UseColumnTextForButtonValue = True
        '
        'cbxTipoInforme
        '
        Me.cbxTipoInforme.FormattingEnabled = True
        Me.cbxTipoInforme.Location = New System.Drawing.Point(165, 133)
        Me.cbxTipoInforme.Name = "cbxTipoInforme"
        Me.cbxTipoInforme.Size = New System.Drawing.Size(373, 24)
        Me.cbxTipoInforme.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 17)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "N° de Solicitud"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 17)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Productor"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(140, 17)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Fecha desde y hasta"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 17)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Tipo Informe"
        '
        'FormBuscarSolicitud
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1637, 683)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbxTipoInforme)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.DateTimeDesde)
        Me.Controls.Add(Me.DateTimeHasta)
        Me.Controls.Add(Me.TextProductor)
        Me.Controls.Add(Me.ButtonBuscarProductor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextIdProductor)
        Me.Controls.Add(Me.Textficha)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormBuscarSolicitud"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar solicitud"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Textficha As System.Windows.Forms.TextBox
    Friend WithEvents TextIdProductor As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonBuscarProductor As System.Windows.Forms.Button
    Friend WithEvents TextProductor As System.Windows.Forms.TextBox
    Friend WithEvents DateTimeHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimeDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents cbxTipoInforme As System.Windows.Forms.ComboBox
    Friend WithEvents Ficha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Muestras As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NoAptas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Analisis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Observaciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Estado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pago As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ObsInternas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoMuestra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pagook As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Seleccionar As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Excel As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
