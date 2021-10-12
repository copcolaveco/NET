<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEstadisticasCalidad
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
        Me.ButtonListar = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.TextEmpresa = New System.Windows.Forms.TextBox
        Me.ButtonBuscarEmpresa = New System.Windows.Forms.Button
        Me.TextIdEmpresa = New System.Windows.Forms.TextBox
        Me.ButtonLimpiar = New System.Windows.Forms.Button
        Me.NumericMes = New System.Windows.Forms.NumericUpDown
        Me.NumericAnio = New System.Windows.Forms.NumericUpDown
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.DateDesde = New System.Windows.Forms.DateTimePicker
        Me.DateHasta = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextProductor = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.TextIdProductor = New System.Windows.Forms.TextBox
        CType(Me.NumericMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonListar
        '
        Me.ButtonListar.Location = New System.Drawing.Point(271, 58)
        Me.ButtonListar.Name = "ButtonListar"
        Me.ButtonListar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonListar.TabIndex = 4
        Me.ButtonListar.Text = "Listar"
        Me.ButtonListar.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(93, 91)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Empresa"
        '
        'TextEmpresa
        '
        Me.TextEmpresa.Location = New System.Drawing.Point(93, 107)
        Me.TextEmpresa.Name = "TextEmpresa"
        Me.TextEmpresa.ReadOnly = True
        Me.TextEmpresa.Size = New System.Drawing.Size(243, 20)
        Me.TextEmpresa.TabIndex = 28
        '
        'ButtonBuscarEmpresa
        '
        Me.ButtonBuscarEmpresa.Location = New System.Drawing.Point(69, 104)
        Me.ButtonBuscarEmpresa.Name = "ButtonBuscarEmpresa"
        Me.ButtonBuscarEmpresa.Size = New System.Drawing.Size(18, 23)
        Me.ButtonBuscarEmpresa.TabIndex = 26
        Me.ButtonBuscarEmpresa.Text = "^"
        Me.ButtonBuscarEmpresa.UseVisualStyleBackColor = True
        '
        'TextIdEmpresa
        '
        Me.TextIdEmpresa.Location = New System.Drawing.Point(11, 107)
        Me.TextIdEmpresa.Name = "TextIdEmpresa"
        Me.TextIdEmpresa.ReadOnly = True
        Me.TextIdEmpresa.Size = New System.Drawing.Size(52, 20)
        Me.TextIdEmpresa.TabIndex = 27
        '
        'ButtonLimpiar
        '
        Me.ButtonLimpiar.Location = New System.Drawing.Point(11, 133)
        Me.ButtonLimpiar.Name = "ButtonLimpiar"
        Me.ButtonLimpiar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonLimpiar.TabIndex = 44
        Me.ButtonLimpiar.Text = "Limpiar"
        Me.ButtonLimpiar.UseVisualStyleBackColor = True
        '
        'NumericMes
        '
        Me.NumericMes.Location = New System.Drawing.Point(236, 254)
        Me.NumericMes.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NumericMes.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericMes.Name = "NumericMes"
        Me.NumericMes.Size = New System.Drawing.Size(63, 20)
        Me.NumericMes.TabIndex = 45
        Me.NumericMes.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NumericAnio
        '
        Me.NumericAnio.Location = New System.Drawing.Point(305, 254)
        Me.NumericAnio.Maximum = New Decimal(New Integer() {2020, 0, 0, 0})
        Me.NumericAnio.Minimum = New Decimal(New Integer() {2012, 0, 0, 0})
        Me.NumericAnio.Name = "NumericAnio"
        Me.NumericAnio.Size = New System.Drawing.Size(63, 20)
        Me.NumericAnio.TabIndex = 46
        Me.NumericAnio.Value = New Decimal(New Integer() {2013, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(233, 238)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "Mes"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(302, 238)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 13)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "Año"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(11, 12)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(357, 23)
        Me.ProgressBar1.TabIndex = 49
        '
        'DateDesde
        '
        Me.DateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDesde.Location = New System.Drawing.Point(13, 61)
        Me.DateDesde.Name = "DateDesde"
        Me.DateDesde.Size = New System.Drawing.Size(94, 20)
        Me.DateDesde.TabIndex = 50
        '
        'DateHasta
        '
        Me.DateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateHasta.Location = New System.Drawing.Point(113, 61)
        Me.DateHasta.Name = "DateHasta"
        Me.DateHasta.Size = New System.Drawing.Size(94, 20)
        Me.DateHasta.TabIndex = 51
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "Desde"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(110, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "Hasta"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(14, 208)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 58
        Me.Button1.Text = "Limpiar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(96, 166)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 57
        Me.Label5.Text = "Productor"
        '
        'TextProductor
        '
        Me.TextProductor.Location = New System.Drawing.Point(96, 182)
        Me.TextProductor.Name = "TextProductor"
        Me.TextProductor.ReadOnly = True
        Me.TextProductor.Size = New System.Drawing.Size(243, 20)
        Me.TextProductor.TabIndex = 56
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(72, 179)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(18, 23)
        Me.Button2.TabIndex = 54
        Me.Button2.Text = "^"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextIdProductor
        '
        Me.TextIdProductor.Location = New System.Drawing.Point(14, 182)
        Me.TextIdProductor.Name = "TextIdProductor"
        Me.TextIdProductor.ReadOnly = True
        Me.TextIdProductor.Size = New System.Drawing.Size(52, 20)
        Me.TextIdProductor.TabIndex = 55
        '
        'FormEstadisticasCalidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(380, 286)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextProductor)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TextIdProductor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateHasta)
        Me.Controls.Add(Me.DateDesde)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.NumericAnio)
        Me.Controls.Add(Me.NumericMes)
        Me.Controls.Add(Me.ButtonLimpiar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextEmpresa)
        Me.Controls.Add(Me.ButtonBuscarEmpresa)
        Me.Controls.Add(Me.TextIdEmpresa)
        Me.Controls.Add(Me.ButtonListar)
        Me.Name = "FormEstadisticasCalidad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estadísticas Calidad de Leche"
        CType(Me.NumericMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericAnio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonListar As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents ButtonBuscarEmpresa As System.Windows.Forms.Button
    Friend WithEvents TextIdEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents ButtonLimpiar As System.Windows.Forms.Button
    Friend WithEvents NumericMes As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericAnio As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents DateDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextProductor As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextIdProductor As System.Windows.Forms.TextBox
End Class
