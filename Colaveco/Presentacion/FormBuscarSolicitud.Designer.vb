﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBuscarSolicitud))
        Me.RadioButtonSolicitud = New System.Windows.Forms.RadioButton
        Me.RadioButtonProductor = New System.Windows.Forms.RadioButton
        Me.RadioButtonFechas = New System.Windows.Forms.RadioButton
        Me.TextIdSolicitud = New System.Windows.Forms.TextBox
        Me.TextIdProductor = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ButtonBuscarProductor = New System.Windows.Forms.Button
        Me.TextProductor = New System.Windows.Forms.TextBox
        Me.DateTimeHasta = New System.Windows.Forms.DateTimePicker
        Me.DateTimeDesde = New System.Windows.Forms.DateTimePicker
        Me.Button2 = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Ficha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Muestras = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Analisis = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Seleccionar = New System.Windows.Forms.DataGridViewButtonColumn
        Me.Excel = New System.Windows.Forms.DataGridViewButtonColumn
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadioButtonSolicitud
        '
        Me.RadioButtonSolicitud.AutoSize = True
        Me.RadioButtonSolicitud.Location = New System.Drawing.Point(15, 32)
        Me.RadioButtonSolicitud.Name = "RadioButtonSolicitud"
        Me.RadioButtonSolicitud.Size = New System.Drawing.Size(93, 17)
        Me.RadioButtonSolicitud.TabIndex = 0
        Me.RadioButtonSolicitud.TabStop = True
        Me.RadioButtonSolicitud.Text = "Nº de solicitud"
        Me.RadioButtonSolicitud.UseVisualStyleBackColor = True
        '
        'RadioButtonProductor
        '
        Me.RadioButtonProductor.AutoSize = True
        Me.RadioButtonProductor.Location = New System.Drawing.Point(15, 59)
        Me.RadioButtonProductor.Name = "RadioButtonProductor"
        Me.RadioButtonProductor.Size = New System.Drawing.Size(71, 17)
        Me.RadioButtonProductor.TabIndex = 1
        Me.RadioButtonProductor.TabStop = True
        Me.RadioButtonProductor.Text = "Productor"
        Me.RadioButtonProductor.UseVisualStyleBackColor = True
        '
        'RadioButtonFechas
        '
        Me.RadioButtonFechas.AutoSize = True
        Me.RadioButtonFechas.Location = New System.Drawing.Point(15, 86)
        Me.RadioButtonFechas.Name = "RadioButtonFechas"
        Me.RadioButtonFechas.Size = New System.Drawing.Size(60, 17)
        Me.RadioButtonFechas.TabIndex = 2
        Me.RadioButtonFechas.TabStop = True
        Me.RadioButtonFechas.Text = "Fechas"
        Me.RadioButtonFechas.UseVisualStyleBackColor = True
        '
        'TextIdSolicitud
        '
        Me.TextIdSolicitud.Location = New System.Drawing.Point(114, 31)
        Me.TextIdSolicitud.Name = "TextIdSolicitud"
        Me.TextIdSolicitud.Size = New System.Drawing.Size(78, 20)
        Me.TextIdSolicitud.TabIndex = 4
        '
        'TextIdProductor
        '
        Me.TextIdProductor.Location = New System.Drawing.Point(114, 57)
        Me.TextIdProductor.Name = "TextIdProductor"
        Me.TextIdProductor.Size = New System.Drawing.Size(57, 20)
        Me.TextIdProductor.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Buscar solicitud por:"
        '
        'ButtonBuscarProductor
        '
        Me.ButtonBuscarProductor.Location = New System.Drawing.Point(177, 59)
        Me.ButtonBuscarProductor.Name = "ButtonBuscarProductor"
        Me.ButtonBuscarProductor.Size = New System.Drawing.Size(21, 19)
        Me.ButtonBuscarProductor.TabIndex = 7
        Me.ButtonBuscarProductor.Text = "^"
        Me.ButtonBuscarProductor.UseVisualStyleBackColor = True
        '
        'TextProductor
        '
        Me.TextProductor.Location = New System.Drawing.Point(204, 58)
        Me.TextProductor.Name = "TextProductor"
        Me.TextProductor.Size = New System.Drawing.Size(258, 20)
        Me.TextProductor.TabIndex = 8
        '
        'DateTimeHasta
        '
        Me.DateTimeHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimeHasta.Location = New System.Drawing.Point(212, 84)
        Me.DateTimeHasta.Name = "DateTimeHasta"
        Me.DateTimeHasta.Size = New System.Drawing.Size(92, 20)
        Me.DateTimeHasta.TabIndex = 9
        '
        'DateTimeDesde
        '
        Me.DateTimeDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimeDesde.Location = New System.Drawing.Point(114, 84)
        Me.DateTimeDesde.Name = "DateTimeDesde"
        Me.DateTimeDesde.Size = New System.Drawing.Size(92, 20)
        Me.DateTimeDesde.TabIndex = 10
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(483, 58)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "Buscar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Ficha, Me.Fecha, Me.Muestras, Me.Analisis, Me.Cliente, Me.Observaciones, Me.Seleccionar, Me.Excel})
        Me.DataGridView1.Location = New System.Drawing.Point(15, 120)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1016, 369)
        Me.DataGridView1.TabIndex = 14
        '
        'Ficha
        '
        Me.Ficha.HeaderText = "Ficha"
        Me.Ficha.Name = "Ficha"
        Me.Ficha.Width = 50
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
        'FormBuscarSolicitud
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1043, 555)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.DateTimeDesde)
        Me.Controls.Add(Me.DateTimeHasta)
        Me.Controls.Add(Me.TextProductor)
        Me.Controls.Add(Me.ButtonBuscarProductor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextIdProductor)
        Me.Controls.Add(Me.TextIdSolicitud)
        Me.Controls.Add(Me.RadioButtonFechas)
        Me.Controls.Add(Me.RadioButtonProductor)
        Me.Controls.Add(Me.RadioButtonSolicitud)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormBuscarSolicitud"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar solicitud"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RadioButtonSolicitud As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonProductor As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonFechas As System.Windows.Forms.RadioButton
    Friend WithEvents TextIdSolicitud As System.Windows.Forms.TextBox
    Friend WithEvents TextIdProductor As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonBuscarProductor As System.Windows.Forms.Button
    Friend WithEvents TextProductor As System.Windows.Forms.TextBox
    Friend WithEvents DateTimeHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimeDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Ficha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Muestras As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Analisis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Observaciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Seleccionar As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Excel As System.Windows.Forms.DataGridViewButtonColumn
End Class
