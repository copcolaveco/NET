<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBuscarDescarte
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBuscarDescarte))
        Me.RadioButtonProductor = New System.Windows.Forms.RadioButton
        Me.RadioButtonFecha = New System.Windows.Forms.RadioButton
        Me.RadioButtonFicha = New System.Windows.Forms.RadioButton
        Me.TextProductor = New System.Windows.Forms.TextBox
        Me.ButtonSeleccionar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextFicha = New System.Windows.Forms.TextBox
        Me.ButtonBuscar = New System.Windows.Forms.Button
        Me.ListResultados = New System.Windows.Forms.ListBox
        Me.TextIdProductor = New System.Windows.Forms.TextBox
        Me.DateDesde = New System.Windows.Forms.DateTimePicker
        Me.DateHasta = New System.Windows.Forms.DateTimePicker
        Me.SuspendLayout()
        '
        'RadioButtonProductor
        '
        Me.RadioButtonProductor.AutoSize = True
        Me.RadioButtonProductor.Location = New System.Drawing.Point(12, 12)
        Me.RadioButtonProductor.Name = "RadioButtonProductor"
        Me.RadioButtonProductor.Size = New System.Drawing.Size(90, 17)
        Me.RadioButtonProductor.TabIndex = 0
        Me.RadioButtonProductor.TabStop = True
        Me.RadioButtonProductor.Text = "Por Productor"
        Me.RadioButtonProductor.UseVisualStyleBackColor = True
        '
        'RadioButtonFecha
        '
        Me.RadioButtonFecha.AutoSize = True
        Me.RadioButtonFecha.Location = New System.Drawing.Point(12, 41)
        Me.RadioButtonFecha.Name = "RadioButtonFecha"
        Me.RadioButtonFecha.Size = New System.Drawing.Size(74, 17)
        Me.RadioButtonFecha.TabIndex = 1
        Me.RadioButtonFecha.TabStop = True
        Me.RadioButtonFecha.Text = "Por Fecha"
        Me.RadioButtonFecha.UseVisualStyleBackColor = True
        '
        'RadioButtonFicha
        '
        Me.RadioButtonFicha.AutoSize = True
        Me.RadioButtonFicha.Location = New System.Drawing.Point(12, 73)
        Me.RadioButtonFicha.Name = "RadioButtonFicha"
        Me.RadioButtonFicha.Size = New System.Drawing.Size(70, 17)
        Me.RadioButtonFicha.TabIndex = 2
        Me.RadioButtonFicha.TabStop = True
        Me.RadioButtonFicha.Text = "Por Ficha"
        Me.RadioButtonFicha.UseVisualStyleBackColor = True
        '
        'TextProductor
        '
        Me.TextProductor.Location = New System.Drawing.Point(204, 14)
        Me.TextProductor.Name = "TextProductor"
        Me.TextProductor.Size = New System.Drawing.Size(255, 20)
        Me.TextProductor.TabIndex = 3
        '
        'ButtonSeleccionar
        '
        Me.ButtonSeleccionar.Location = New System.Drawing.Point(181, 12)
        Me.ButtonSeleccionar.Name = "ButtonSeleccionar"
        Me.ButtonSeleccionar.Size = New System.Drawing.Size(17, 22)
        Me.ButtonSeleccionar.TabIndex = 4
        Me.ButtonSeleccionar.Text = "^"
        Me.ButtonSeleccionar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(120, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Desde"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(261, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "hasta"
        '
        'TextFicha
        '
        Me.TextFicha.Location = New System.Drawing.Point(123, 70)
        Me.TextFicha.Name = "TextFicha"
        Me.TextFicha.Size = New System.Drawing.Size(52, 20)
        Me.TextFicha.TabIndex = 9
        '
        'ButtonBuscar
        '
        Me.ButtonBuscar.Location = New System.Drawing.Point(384, 125)
        Me.ButtonBuscar.Name = "ButtonBuscar"
        Me.ButtonBuscar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonBuscar.TabIndex = 10
        Me.ButtonBuscar.Text = "Buscar"
        Me.ButtonBuscar.UseVisualStyleBackColor = True
        '
        'ListResultados
        '
        Me.ListResultados.FormattingEnabled = True
        Me.ListResultados.Location = New System.Drawing.Point(475, 14)
        Me.ListResultados.Name = "ListResultados"
        Me.ListResultados.Size = New System.Drawing.Size(326, 134)
        Me.ListResultados.TabIndex = 11
        '
        'TextIdProductor
        '
        Me.TextIdProductor.Location = New System.Drawing.Point(123, 14)
        Me.TextIdProductor.Name = "TextIdProductor"
        Me.TextIdProductor.Size = New System.Drawing.Size(52, 20)
        Me.TextIdProductor.TabIndex = 12
        '
        'DateDesde
        '
        Me.DateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDesde.Location = New System.Drawing.Point(164, 41)
        Me.DateDesde.Name = "DateDesde"
        Me.DateDesde.Size = New System.Drawing.Size(91, 20)
        Me.DateDesde.TabIndex = 13
        '
        'DateHasta
        '
        Me.DateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateHasta.Location = New System.Drawing.Point(300, 41)
        Me.DateHasta.Name = "DateHasta"
        Me.DateHasta.Size = New System.Drawing.Size(91, 20)
        Me.DateHasta.TabIndex = 14
        '
        'FormBuscarDescarte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(813, 160)
        Me.Controls.Add(Me.DateHasta)
        Me.Controls.Add(Me.DateDesde)
        Me.Controls.Add(Me.TextIdProductor)
        Me.Controls.Add(Me.ListResultados)
        Me.Controls.Add(Me.ButtonBuscar)
        Me.Controls.Add(Me.TextFicha)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButtonSeleccionar)
        Me.Controls.Add(Me.TextProductor)
        Me.Controls.Add(Me.RadioButtonFicha)
        Me.Controls.Add(Me.RadioButtonFecha)
        Me.Controls.Add(Me.RadioButtonProductor)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormBuscarDescarte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Descarte de Muestras"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RadioButtonProductor As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonFecha As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonFicha As System.Windows.Forms.RadioButton
    Friend WithEvents TextProductor As System.Windows.Forms.TextBox
    Friend WithEvents ButtonSeleccionar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextFicha As System.Windows.Forms.TextBox
    Friend WithEvents ButtonBuscar As System.Windows.Forms.Button
    Friend WithEvents ListResultados As System.Windows.Forms.ListBox
    Friend WithEvents TextIdProductor As System.Windows.Forms.TextBox
    Friend WithEvents DateDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateHasta As System.Windows.Forms.DateTimePicker
End Class
