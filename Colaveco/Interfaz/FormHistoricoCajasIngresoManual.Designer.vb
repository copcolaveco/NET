<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormHistoricoCajasIngresoManual
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Productor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Caja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaEnvio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Devuelta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaRecibo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ObsRecibo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateDesde = New System.Windows.Forms.DateTimePicker()
        Me.DateHasta = New System.Windows.Forms.DateTimePicker()
        Me.Hasta = New System.Windows.Forms.Label()
        Me.Desde = New System.Windows.Forms.Label()
        Me.ButtonBuscar = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Productor, Me.Caja, Me.FechaEnvio, Me.Observaciones, Me.Devuelta, Me.FechaRecibo, Me.ObsRecibo, Me.UsuarioNombre})
        Me.DataGridView1.Location = New System.Drawing.Point(161, 13)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(1502, 546)
        Me.DataGridView1.TabIndex = 3
        '
        'Productor
        '
        Me.Productor.HeaderText = "Productor"
        Me.Productor.Name = "Productor"
        Me.Productor.Width = 200
        '
        'Caja
        '
        Me.Caja.HeaderText = "Caja"
        Me.Caja.Name = "Caja"
        Me.Caja.Width = 50
        '
        'FechaEnvio
        '
        Me.FechaEnvio.HeaderText = "Fecha envío"
        Me.FechaEnvio.Name = "FechaEnvio"
        Me.FechaEnvio.Width = 80
        '
        'Observaciones
        '
        Me.Observaciones.HeaderText = "Observaciones"
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.Width = 200
        '
        'Devuelta
        '
        Me.Devuelta.HeaderText = "Devuelta"
        Me.Devuelta.Name = "Devuelta"
        Me.Devuelta.Width = 60
        '
        'FechaRecibo
        '
        Me.FechaRecibo.HeaderText = "Fecha devuelta"
        Me.FechaRecibo.Name = "FechaRecibo"
        '
        'ObsRecibo
        '
        Me.ObsRecibo.HeaderText = "Obs. Recibo"
        Me.ObsRecibo.Name = "ObsRecibo"
        Me.ObsRecibo.Width = 200
        '
        'UsuarioNombre
        '
        Me.UsuarioNombre.HeaderText = "UsuarioNombre"
        Me.UsuarioNombre.Name = "UsuarioNombre"
        '
        'DateDesde
        '
        Me.DateDesde.Location = New System.Drawing.Point(12, 82)
        Me.DateDesde.Name = "DateDesde"
        Me.DateDesde.Size = New System.Drawing.Size(127, 22)
        Me.DateDesde.TabIndex = 4
        '
        'DateHasta
        '
        Me.DateHasta.Location = New System.Drawing.Point(12, 148)
        Me.DateHasta.Name = "DateHasta"
        Me.DateHasta.Size = New System.Drawing.Size(127, 22)
        Me.DateHasta.TabIndex = 5
        '
        'Hasta
        '
        Me.Hasta.AutoSize = True
        Me.Hasta.Location = New System.Drawing.Point(13, 125)
        Me.Hasta.Name = "Hasta"
        Me.Hasta.Size = New System.Drawing.Size(45, 17)
        Me.Hasta.TabIndex = 6
        Me.Hasta.Text = "Hasta"
        '
        'Desde
        '
        Me.Desde.AutoSize = True
        Me.Desde.Location = New System.Drawing.Point(12, 62)
        Me.Desde.Name = "Desde"
        Me.Desde.Size = New System.Drawing.Size(49, 17)
        Me.Desde.TabIndex = 7
        Me.Desde.Text = "Desde"
        '
        'ButtonBuscar
        '
        Me.ButtonBuscar.Location = New System.Drawing.Point(12, 203)
        Me.ButtonBuscar.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonBuscar.Name = "ButtonBuscar"
        Me.ButtonBuscar.Size = New System.Drawing.Size(127, 36)
        Me.ButtonBuscar.TabIndex = 8
        Me.ButtonBuscar.Text = "Buscar"
        Me.ButtonBuscar.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 247)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(127, 35)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "EXCEL"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FormHistoricoCajasIngresoManual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1676, 572)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ButtonBuscar)
        Me.Controls.Add(Me.Desde)
        Me.Controls.Add(Me.Hasta)
        Me.Controls.Add(Me.DateHasta)
        Me.Controls.Add(Me.DateDesde)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "FormHistoricoCajasIngresoManual"
        Me.Text = "FormHistoricoCajasIngresoManual"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Productor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Caja As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaEnvio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Observaciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Devuelta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaRecibo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ObsRecibo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsuarioNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Hasta As System.Windows.Forms.Label
    Friend WithEvents Desde As System.Windows.Forms.Label
    Friend WithEvents ButtonBuscar As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
