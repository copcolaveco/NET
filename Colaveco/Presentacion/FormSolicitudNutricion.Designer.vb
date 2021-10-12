<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSolicitudNutricion
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.RadioPasturas = New System.Windows.Forms.RadioButton
        Me.RadioEnsilados = New System.Windows.Forms.RadioButton
        Me.RadioMGB = New System.Windows.Forms.RadioButton
        Me.RadioMGA = New System.Windows.Forms.RadioButton
        Me.CheckExtEtereo = New System.Windows.Forms.CheckBox
        Me.CheckNida = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.ButtonCerrar = New System.Windows.Forms.Button
        Me.TextFicha = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.LabelMuestras = New System.Windows.Forms.Label
        Me.TextId = New System.Windows.Forms.TextBox
        Me.ButtonEliminar = New System.Windows.Forms.Button
        Me.ListMuestras = New System.Windows.Forms.ListBox
        Me.TextMuestra = New System.Windows.Forms.TextBox
        Me.DateFechaIngreso = New System.Windows.Forms.DateTimePicker
        Me.RadioMicotoxinas = New System.Windows.Forms.RadioButton
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioMicotoxinas)
        Me.GroupBox1.Controls.Add(Me.TextBox4)
        Me.GroupBox1.Controls.Add(Me.TextBox3)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.RadioPasturas)
        Me.GroupBox1.Controls.Add(Me.RadioEnsilados)
        Me.GroupBox1.Controls.Add(Me.RadioMGB)
        Me.GroupBox1.Controls.Add(Me.RadioMGA)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(406, 160)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Paquetes"
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox4.Location = New System.Drawing.Point(98, 105)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(284, 20)
        Me.TextBox4.TabIndex = 10
        Me.TextBox4.Text = "MS, Cenizas, PB, FND, FAD, Cálculo de energía."
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox3.Location = New System.Drawing.Point(98, 79)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(284, 20)
        Me.TextBox3.TabIndex = 9
        Me.TextBox3.Text = "MS, PB, pH, Cenizas, FAD, FND, Cálculo de energía."
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox2.Location = New System.Drawing.Point(98, 53)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(284, 20)
        Me.TextBox2.TabIndex = 8
        Me.TextBox2.Text = "MS, Cenizas, PB, FC."
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox1.Location = New System.Drawing.Point(98, 27)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(284, 20)
        Me.TextBox1.TabIndex = 7
        Me.TextBox1.Text = "MS, Cenizas, PB, FND, FAD, Cálculo de energía."
        '
        'RadioPasturas
        '
        Me.RadioPasturas.AutoSize = True
        Me.RadioPasturas.Location = New System.Drawing.Point(16, 106)
        Me.RadioPasturas.Name = "RadioPasturas"
        Me.RadioPasturas.Size = New System.Drawing.Size(66, 17)
        Me.RadioPasturas.TabIndex = 3
        Me.RadioPasturas.TabStop = True
        Me.RadioPasturas.Text = "Pasturas"
        Me.RadioPasturas.UseVisualStyleBackColor = True
        '
        'RadioEnsilados
        '
        Me.RadioEnsilados.AutoSize = True
        Me.RadioEnsilados.Location = New System.Drawing.Point(16, 80)
        Me.RadioEnsilados.Name = "RadioEnsilados"
        Me.RadioEnsilados.Size = New System.Drawing.Size(70, 17)
        Me.RadioEnsilados.TabIndex = 2
        Me.RadioEnsilados.TabStop = True
        Me.RadioEnsilados.Text = "Ensilados"
        Me.RadioEnsilados.UseVisualStyleBackColor = True
        '
        'RadioMGB
        '
        Me.RadioMGB.AutoSize = True
        Me.RadioMGB.Location = New System.Drawing.Point(16, 54)
        Me.RadioMGB.Name = "RadioMGB"
        Me.RadioMGB.Size = New System.Drawing.Size(51, 17)
        Me.RadioMGB.TabIndex = 1
        Me.RadioMGB.TabStop = True
        Me.RadioMGB.Text = "MG-b"
        Me.RadioMGB.UseVisualStyleBackColor = True
        '
        'RadioMGA
        '
        Me.RadioMGA.AutoSize = True
        Me.RadioMGA.Location = New System.Drawing.Point(16, 28)
        Me.RadioMGA.Name = "RadioMGA"
        Me.RadioMGA.Size = New System.Drawing.Size(51, 17)
        Me.RadioMGA.TabIndex = 0
        Me.RadioMGA.TabStop = True
        Me.RadioMGA.Text = "MG-a"
        Me.RadioMGA.UseVisualStyleBackColor = True
        '
        'CheckExtEtereo
        '
        Me.CheckExtEtereo.AutoSize = True
        Me.CheckExtEtereo.Location = New System.Drawing.Point(16, 19)
        Me.CheckExtEtereo.Name = "CheckExtEtereo"
        Me.CheckExtEtereo.Size = New System.Drawing.Size(98, 17)
        Me.CheckExtEtereo.TabIndex = 4
        Me.CheckExtEtereo.Text = "Extracto etéreo"
        Me.CheckExtEtereo.UseVisualStyleBackColor = True
        '
        'CheckNida
        '
        Me.CheckNida.AutoSize = True
        Me.CheckNida.Location = New System.Drawing.Point(16, 42)
        Me.CheckNida.Name = "CheckNida"
        Me.CheckNida.Size = New System.Drawing.Size(52, 17)
        Me.CheckNida.TabIndex = 5
        Me.CheckNida.Text = "NIDA"
        Me.CheckNida.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextBox5)
        Me.GroupBox2.Controls.Add(Me.CheckExtEtereo)
        Me.GroupBox2.Controls.Add(Me.CheckNida)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 202)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(406, 72)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Análisis"
        '
        'TextBox5
        '
        Me.TextBox5.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox5.Location = New System.Drawing.Point(98, 40)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(284, 20)
        Me.TextBox5.TabIndex = 11
        Me.TextBox5.Text = "Nitrógeno insoluble en detergente ácido."
        '
        'ButtonCerrar
        '
        Me.ButtonCerrar.Location = New System.Drawing.Point(424, 280)
        Me.ButtonCerrar.Name = "ButtonCerrar"
        Me.ButtonCerrar.Size = New System.Drawing.Size(186, 23)
        Me.ButtonCerrar.TabIndex = 7
        Me.ButtonCerrar.Text = "Cerrar"
        Me.ButtonCerrar.UseVisualStyleBackColor = True
        '
        'TextFicha
        '
        Me.TextFicha.Location = New System.Drawing.Point(66, 6)
        Me.TextFicha.Name = "TextFicha"
        Me.TextFicha.ReadOnly = True
        Me.TextFicha.Size = New System.Drawing.Size(60, 20)
        Me.TextFicha.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Nº Ficha"
        '
        'LabelMuestras
        '
        Me.LabelMuestras.AutoSize = True
        Me.LabelMuestras.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMuestras.ForeColor = System.Drawing.Color.Red
        Me.LabelMuestras.Location = New System.Drawing.Point(616, 59)
        Me.LabelMuestras.Name = "LabelMuestras"
        Me.LabelMuestras.Size = New System.Drawing.Size(0, 20)
        Me.LabelMuestras.TabIndex = 27
        '
        'TextId
        '
        Me.TextId.Enabled = False
        Me.TextId.Location = New System.Drawing.Point(616, 65)
        Me.TextId.Name = "TextId"
        Me.TextId.Size = New System.Drawing.Size(49, 20)
        Me.TextId.TabIndex = 26
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(616, 36)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(55, 23)
        Me.ButtonEliminar.TabIndex = 25
        Me.ButtonEliminar.Text = "Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'ListMuestras
        '
        Me.ListMuestras.FormattingEnabled = True
        Me.ListMuestras.Location = New System.Drawing.Point(424, 36)
        Me.ListMuestras.Name = "ListMuestras"
        Me.ListMuestras.Size = New System.Drawing.Size(186, 238)
        Me.ListMuestras.TabIndex = 24
        '
        'TextMuestra
        '
        Me.TextMuestra.Location = New System.Drawing.Point(424, 10)
        Me.TextMuestra.Name = "TextMuestra"
        Me.TextMuestra.Size = New System.Drawing.Size(186, 20)
        Me.TextMuestra.TabIndex = 23
        '
        'DateFechaIngreso
        '
        Me.DateFechaIngreso.Enabled = False
        Me.DateFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFechaIngreso.Location = New System.Drawing.Point(132, 6)
        Me.DateFechaIngreso.Name = "DateFechaIngreso"
        Me.DateFechaIngreso.Size = New System.Drawing.Size(95, 20)
        Me.DateFechaIngreso.TabIndex = 28
        '
        'RadioMicotoxinas
        '
        Me.RadioMicotoxinas.AutoSize = True
        Me.RadioMicotoxinas.Location = New System.Drawing.Point(16, 131)
        Me.RadioMicotoxinas.Name = "RadioMicotoxinas"
        Me.RadioMicotoxinas.Size = New System.Drawing.Size(81, 17)
        Me.RadioMicotoxinas.TabIndex = 11
        Me.RadioMicotoxinas.TabStop = True
        Me.RadioMicotoxinas.Text = "Micotoxinas"
        Me.RadioMicotoxinas.UseVisualStyleBackColor = True
        '
        'FormSolicitudNutricion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 315)
        Me.Controls.Add(Me.DateFechaIngreso)
        Me.Controls.Add(Me.LabelMuestras)
        Me.Controls.Add(Me.TextId)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.ListMuestras)
        Me.Controls.Add(Me.TextMuestra)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextFicha)
        Me.Controls.Add(Me.ButtonCerrar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FormSolicitudNutricion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solicitud nutrición"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioPasturas As System.Windows.Forms.RadioButton
    Friend WithEvents RadioEnsilados As System.Windows.Forms.RadioButton
    Friend WithEvents RadioMGB As System.Windows.Forms.RadioButton
    Friend WithEvents RadioMGA As System.Windows.Forms.RadioButton
    Friend WithEvents CheckExtEtereo As System.Windows.Forms.CheckBox
    Friend WithEvents CheckNida As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents ButtonCerrar As System.Windows.Forms.Button
    Friend WithEvents TextFicha As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LabelMuestras As System.Windows.Forms.Label
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents ListMuestras As System.Windows.Forms.ListBox
    Friend WithEvents TextMuestra As System.Windows.Forms.TextBox
    Friend WithEvents DateFechaIngreso As System.Windows.Forms.DateTimePicker
    Friend WithEvents RadioMicotoxinas As System.Windows.Forms.RadioButton
End Class
