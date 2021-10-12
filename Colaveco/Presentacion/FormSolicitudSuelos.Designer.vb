<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSolicitudSuelos
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
        Me.CheckSodio = New System.Windows.Forms.CheckBox
        Me.CheckMagnesio = New System.Windows.Forms.CheckBox
        Me.CheckCalcio = New System.Windows.Forms.CheckBox
        Me.CheckPHKCI = New System.Windows.Forms.CheckBox
        Me.CheckNitrogenoVegetal = New System.Windows.Forms.CheckBox
        Me.CheckSulfatos = New System.Windows.Forms.CheckBox
        Me.CheckPotasioInt = New System.Windows.Forms.CheckBox
        Me.CheckMateriaOrg = New System.Windows.Forms.CheckBox
        Me.CheckPHAgua = New System.Windows.Forms.CheckBox
        Me.CheckFosforoCitrico = New System.Windows.Forms.CheckBox
        Me.CheckFosforoBray = New System.Windows.Forms.CheckBox
        Me.CheckMineralizacion = New System.Windows.Forms.CheckBox
        Me.CheckNitratos = New System.Windows.Forms.CheckBox
        Me.LabelMuestras = New System.Windows.Forms.Label
        Me.TextId = New System.Windows.Forms.TextBox
        Me.ButtonEliminar = New System.Windows.Forms.Button
        Me.ListMuestras = New System.Windows.Forms.ListBox
        Me.TextMuestra = New System.Windows.Forms.TextBox
        Me.ButtonCerrar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextFicha = New System.Windows.Forms.TextBox
        Me.DateFechaIngreso = New System.Windows.Forms.DateTimePicker
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.CheckCationes = New System.Windows.Forms.CheckBox
        Me.CheckCultivosInvierno = New System.Windows.Forms.CheckBox
        Me.CheckCultivosVerano = New System.Windows.Forms.CheckBox
        Me.CheckAnalisisCompleto = New System.Windows.Forms.CheckBox
        Me.CheckAcidezT = New System.Windows.Forms.CheckBox
        Me.CheckCIC = New System.Windows.Forms.CheckBox
        Me.CheckSB = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckSB)
        Me.GroupBox1.Controls.Add(Me.CheckSodio)
        Me.GroupBox1.Controls.Add(Me.CheckCIC)
        Me.GroupBox1.Controls.Add(Me.CheckMagnesio)
        Me.GroupBox1.Controls.Add(Me.CheckAcidezT)
        Me.GroupBox1.Controls.Add(Me.CheckCalcio)
        Me.GroupBox1.Controls.Add(Me.CheckPHKCI)
        Me.GroupBox1.Controls.Add(Me.CheckNitrogenoVegetal)
        Me.GroupBox1.Controls.Add(Me.CheckSulfatos)
        Me.GroupBox1.Controls.Add(Me.CheckPotasioInt)
        Me.GroupBox1.Controls.Add(Me.CheckMateriaOrg)
        Me.GroupBox1.Controls.Add(Me.CheckPHAgua)
        Me.GroupBox1.Controls.Add(Me.CheckFosforoCitrico)
        Me.GroupBox1.Controls.Add(Me.CheckFosforoBray)
        Me.GroupBox1.Controls.Add(Me.CheckMineralizacion)
        Me.GroupBox1.Controls.Add(Me.CheckNitratos)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 181)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(185, 395)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Análisis requeridos"
        '
        'CheckSodio
        '
        Me.CheckSodio.AutoSize = True
        Me.CheckSodio.Location = New System.Drawing.Point(6, 295)
        Me.CheckSodio.Name = "CheckSodio"
        Me.CheckSodio.Size = New System.Drawing.Size(53, 17)
        Me.CheckSodio.TabIndex = 38
        Me.CheckSodio.Text = "Sodio"
        Me.CheckSodio.UseVisualStyleBackColor = True
        '
        'CheckMagnesio
        '
        Me.CheckMagnesio.AutoSize = True
        Me.CheckMagnesio.Location = New System.Drawing.Point(6, 272)
        Me.CheckMagnesio.Name = "CheckMagnesio"
        Me.CheckMagnesio.Size = New System.Drawing.Size(72, 17)
        Me.CheckMagnesio.TabIndex = 38
        Me.CheckMagnesio.Text = "Magnesio"
        Me.CheckMagnesio.UseVisualStyleBackColor = True
        '
        'CheckCalcio
        '
        Me.CheckCalcio.AutoSize = True
        Me.CheckCalcio.Location = New System.Drawing.Point(6, 249)
        Me.CheckCalcio.Name = "CheckCalcio"
        Me.CheckCalcio.Size = New System.Drawing.Size(55, 17)
        Me.CheckCalcio.TabIndex = 38
        Me.CheckCalcio.Text = "Calcio"
        Me.CheckCalcio.UseVisualStyleBackColor = True
        '
        'CheckPHKCI
        '
        Me.CheckPHKCI.AutoSize = True
        Me.CheckPHKCI.Location = New System.Drawing.Point(6, 134)
        Me.CheckPHKCI.Name = "CheckPHKCI"
        Me.CheckPHKCI.Size = New System.Drawing.Size(60, 17)
        Me.CheckPHKCI.TabIndex = 37
        Me.CheckPHKCI.Text = "pH KCI"
        Me.CheckPHKCI.UseVisualStyleBackColor = True
        '
        'CheckNitrogenoVegetal
        '
        Me.CheckNitrogenoVegetal.AutoSize = True
        Me.CheckNitrogenoVegetal.Location = New System.Drawing.Point(6, 226)
        Me.CheckNitrogenoVegetal.Name = "CheckNitrogenoVegetal"
        Me.CheckNitrogenoVegetal.Size = New System.Drawing.Size(110, 17)
        Me.CheckNitrogenoVegetal.TabIndex = 36
        Me.CheckNitrogenoVegetal.Text = "Nitrógeno vegetal"
        Me.CheckNitrogenoVegetal.UseVisualStyleBackColor = True
        '
        'CheckSulfatos
        '
        Me.CheckSulfatos.AutoSize = True
        Me.CheckSulfatos.Location = New System.Drawing.Point(6, 203)
        Me.CheckSulfatos.Name = "CheckSulfatos"
        Me.CheckSulfatos.Size = New System.Drawing.Size(64, 17)
        Me.CheckSulfatos.TabIndex = 36
        Me.CheckSulfatos.Text = "Sulfatos"
        Me.CheckSulfatos.UseVisualStyleBackColor = True
        '
        'CheckPotasioInt
        '
        Me.CheckPotasioInt.AutoSize = True
        Me.CheckPotasioInt.Location = New System.Drawing.Point(6, 180)
        Me.CheckPotasioInt.Name = "CheckPotasioInt"
        Me.CheckPotasioInt.Size = New System.Drawing.Size(132, 17)
        Me.CheckPotasioInt.TabIndex = 6
        Me.CheckPotasioInt.Text = "Potasio intercambiable"
        Me.CheckPotasioInt.UseVisualStyleBackColor = True
        '
        'CheckMateriaOrg
        '
        Me.CheckMateriaOrg.AutoSize = True
        Me.CheckMateriaOrg.Location = New System.Drawing.Point(6, 157)
        Me.CheckMateriaOrg.Name = "CheckMateriaOrg"
        Me.CheckMateriaOrg.Size = New System.Drawing.Size(105, 17)
        Me.CheckMateriaOrg.TabIndex = 5
        Me.CheckMateriaOrg.Text = "Materia orgánica"
        Me.CheckMateriaOrg.UseVisualStyleBackColor = True
        '
        'CheckPHAgua
        '
        Me.CheckPHAgua.AutoSize = True
        Me.CheckPHAgua.Location = New System.Drawing.Point(6, 111)
        Me.CheckPHAgua.Name = "CheckPHAgua"
        Me.CheckPHAgua.Size = New System.Drawing.Size(68, 17)
        Me.CheckPHAgua.TabIndex = 4
        Me.CheckPHAgua.Text = "pH Agua"
        Me.CheckPHAgua.UseVisualStyleBackColor = True
        '
        'CheckFosforoCitrico
        '
        Me.CheckFosforoCitrico.AutoSize = True
        Me.CheckFosforoCitrico.Location = New System.Drawing.Point(6, 88)
        Me.CheckFosforoCitrico.Name = "CheckFosforoCitrico"
        Me.CheckFosforoCitrico.Size = New System.Drawing.Size(95, 17)
        Me.CheckFosforoCitrico.TabIndex = 3
        Me.CheckFosforoCitrico.Text = "Fósforo Cítrico"
        Me.CheckFosforoCitrico.UseVisualStyleBackColor = True
        '
        'CheckFosforoBray
        '
        Me.CheckFosforoBray.AutoSize = True
        Me.CheckFosforoBray.Location = New System.Drawing.Point(6, 65)
        Me.CheckFosforoBray.Name = "CheckFosforoBray"
        Me.CheckFosforoBray.Size = New System.Drawing.Size(91, 17)
        Me.CheckFosforoBray.TabIndex = 2
        Me.CheckFosforoBray.Text = "Fósforo Bray I"
        Me.CheckFosforoBray.UseVisualStyleBackColor = True
        '
        'CheckMineralizacion
        '
        Me.CheckMineralizacion.AutoSize = True
        Me.CheckMineralizacion.Location = New System.Drawing.Point(6, 42)
        Me.CheckMineralizacion.Name = "CheckMineralizacion"
        Me.CheckMineralizacion.Size = New System.Drawing.Size(137, 17)
        Me.CheckMineralizacion.TabIndex = 1
        Me.CheckMineralizacion.Text = "Mineralización N (PMN)"
        Me.CheckMineralizacion.UseVisualStyleBackColor = True
        '
        'CheckNitratos
        '
        Me.CheckNitratos.AutoSize = True
        Me.CheckNitratos.Location = New System.Drawing.Point(6, 19)
        Me.CheckNitratos.Name = "CheckNitratos"
        Me.CheckNitratos.Size = New System.Drawing.Size(62, 17)
        Me.CheckNitratos.TabIndex = 0
        Me.CheckNitratos.Text = "Nitratos"
        Me.CheckNitratos.UseVisualStyleBackColor = True
        '
        'LabelMuestras
        '
        Me.LabelMuestras.AutoSize = True
        Me.LabelMuestras.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMuestras.ForeColor = System.Drawing.Color.Red
        Me.LabelMuestras.Location = New System.Drawing.Point(406, 84)
        Me.LabelMuestras.Name = "LabelMuestras"
        Me.LabelMuestras.Size = New System.Drawing.Size(0, 20)
        Me.LabelMuestras.TabIndex = 33
        '
        'TextId
        '
        Me.TextId.Enabled = False
        Me.TextId.Location = New System.Drawing.Point(406, 90)
        Me.TextId.Name = "TextId"
        Me.TextId.Size = New System.Drawing.Size(49, 20)
        Me.TextId.TabIndex = 32
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(406, 61)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(55, 23)
        Me.ButtonEliminar.TabIndex = 31
        Me.ButtonEliminar.Text = "Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'ListMuestras
        '
        Me.ListMuestras.FormattingEnabled = True
        Me.ListMuestras.Location = New System.Drawing.Point(214, 87)
        Me.ListMuestras.Name = "ListMuestras"
        Me.ListMuestras.Size = New System.Drawing.Size(186, 225)
        Me.ListMuestras.TabIndex = 30
        '
        'TextMuestra
        '
        Me.TextMuestra.Location = New System.Drawing.Point(214, 61)
        Me.TextMuestra.Name = "TextMuestra"
        Me.TextMuestra.Size = New System.Drawing.Size(186, 20)
        Me.TextMuestra.TabIndex = 29
        '
        'ButtonCerrar
        '
        Me.ButtonCerrar.Location = New System.Drawing.Point(214, 545)
        Me.ButtonCerrar.Name = "ButtonCerrar"
        Me.ButtonCerrar.Size = New System.Drawing.Size(186, 23)
        Me.ButtonCerrar.TabIndex = 28
        Me.ButtonCerrar.Text = "Cerrar"
        Me.ButtonCerrar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Nº Ficha"
        '
        'TextFicha
        '
        Me.TextFicha.Location = New System.Drawing.Point(69, 17)
        Me.TextFicha.Name = "TextFicha"
        Me.TextFicha.ReadOnly = True
        Me.TextFicha.Size = New System.Drawing.Size(60, 20)
        Me.TextFicha.TabIndex = 34
        '
        'DateFechaIngreso
        '
        Me.DateFechaIngreso.Enabled = False
        Me.DateFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFechaIngreso.Location = New System.Drawing.Point(135, 17)
        Me.DateFechaIngreso.Name = "DateFechaIngreso"
        Me.DateFechaIngreso.Size = New System.Drawing.Size(95, 20)
        Me.DateFechaIngreso.TabIndex = 36
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CheckCationes)
        Me.GroupBox2.Controls.Add(Me.CheckCultivosInvierno)
        Me.GroupBox2.Controls.Add(Me.CheckCultivosVerano)
        Me.GroupBox2.Controls.Add(Me.CheckAnalisisCompleto)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 61)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(185, 114)
        Me.GroupBox2.TabIndex = 37
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Paquetes"
        '
        'CheckCationes
        '
        Me.CheckCationes.AutoSize = True
        Me.CheckCationes.Location = New System.Drawing.Point(6, 88)
        Me.CheckCationes.Name = "CheckCationes"
        Me.CheckCationes.Size = New System.Drawing.Size(67, 17)
        Me.CheckCationes.TabIndex = 38
        Me.CheckCationes.Text = "Cationes"
        Me.CheckCationes.UseVisualStyleBackColor = True
        '
        'CheckCultivosInvierno
        '
        Me.CheckCultivosInvierno.AutoSize = True
        Me.CheckCultivosInvierno.Location = New System.Drawing.Point(6, 65)
        Me.CheckCultivosInvierno.Name = "CheckCultivosInvierno"
        Me.CheckCultivosInvierno.Size = New System.Drawing.Size(118, 17)
        Me.CheckCultivosInvierno.TabIndex = 38
        Me.CheckCultivosInvierno.Text = "Cultivos de invierno"
        Me.CheckCultivosInvierno.UseVisualStyleBackColor = True
        '
        'CheckCultivosVerano
        '
        Me.CheckCultivosVerano.AutoSize = True
        Me.CheckCultivosVerano.Location = New System.Drawing.Point(6, 42)
        Me.CheckCultivosVerano.Name = "CheckCultivosVerano"
        Me.CheckCultivosVerano.Size = New System.Drawing.Size(114, 17)
        Me.CheckCultivosVerano.TabIndex = 38
        Me.CheckCultivosVerano.Text = "Cultivos de verano"
        Me.CheckCultivosVerano.UseVisualStyleBackColor = True
        '
        'CheckAnalisisCompleto
        '
        Me.CheckAnalisisCompleto.AutoSize = True
        Me.CheckAnalisisCompleto.Location = New System.Drawing.Point(6, 19)
        Me.CheckAnalisisCompleto.Name = "CheckAnalisisCompleto"
        Me.CheckAnalisisCompleto.Size = New System.Drawing.Size(107, 17)
        Me.CheckAnalisisCompleto.TabIndex = 38
        Me.CheckAnalisisCompleto.Text = "Análisis completo"
        Me.CheckAnalisisCompleto.UseVisualStyleBackColor = True
        '
        'CheckAcidezT
        '
        Me.CheckAcidezT.AutoSize = True
        Me.CheckAcidezT.Location = New System.Drawing.Point(6, 318)
        Me.CheckAcidezT.Name = "CheckAcidezT"
        Me.CheckAcidezT.Size = New System.Drawing.Size(97, 17)
        Me.CheckAcidezT.TabIndex = 38
        Me.CheckAcidezT.Text = "Acidez titulable"
        Me.CheckAcidezT.UseVisualStyleBackColor = True
        '
        'CheckCIC
        '
        Me.CheckCIC.AutoSize = True
        Me.CheckCIC.Location = New System.Drawing.Point(6, 341)
        Me.CheckCIC.Name = "CheckCIC"
        Me.CheckCIC.Size = New System.Drawing.Size(43, 17)
        Me.CheckCIC.TabIndex = 39
        Me.CheckCIC.Text = "CIC"
        Me.CheckCIC.UseVisualStyleBackColor = True
        '
        'CheckSB
        '
        Me.CheckSB.AutoSize = True
        Me.CheckSB.Location = New System.Drawing.Point(6, 364)
        Me.CheckSB.Name = "CheckSB"
        Me.CheckSB.Size = New System.Drawing.Size(51, 17)
        Me.CheckSB.TabIndex = 40
        Me.CheckSB.Text = "% SB"
        Me.CheckSB.UseVisualStyleBackColor = True
        '
        'FormSolicitudSuelos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(473, 583)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.DateFechaIngreso)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextFicha)
        Me.Controls.Add(Me.LabelMuestras)
        Me.Controls.Add(Me.TextId)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.ListMuestras)
        Me.Controls.Add(Me.TextMuestra)
        Me.Controls.Add(Me.ButtonCerrar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FormSolicitudSuelos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solicitud Suelos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckPotasioInt As System.Windows.Forms.CheckBox
    Friend WithEvents CheckMateriaOrg As System.Windows.Forms.CheckBox
    Friend WithEvents CheckPHAgua As System.Windows.Forms.CheckBox
    Friend WithEvents CheckFosforoCitrico As System.Windows.Forms.CheckBox
    Friend WithEvents CheckFosforoBray As System.Windows.Forms.CheckBox
    Friend WithEvents CheckMineralizacion As System.Windows.Forms.CheckBox
    Friend WithEvents CheckNitratos As System.Windows.Forms.CheckBox
    Friend WithEvents LabelMuestras As System.Windows.Forms.Label
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents ListMuestras As System.Windows.Forms.ListBox
    Friend WithEvents TextMuestra As System.Windows.Forms.TextBox
    Friend WithEvents ButtonCerrar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextFicha As System.Windows.Forms.TextBox
    Friend WithEvents CheckNitrogenoVegetal As System.Windows.Forms.CheckBox
    Friend WithEvents CheckSulfatos As System.Windows.Forms.CheckBox
    Friend WithEvents CheckPHKCI As System.Windows.Forms.CheckBox
    Friend WithEvents DateFechaIngreso As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckCationes As System.Windows.Forms.CheckBox
    Friend WithEvents CheckCultivosInvierno As System.Windows.Forms.CheckBox
    Friend WithEvents CheckCultivosVerano As System.Windows.Forms.CheckBox
    Friend WithEvents CheckAnalisisCompleto As System.Windows.Forms.CheckBox
    Friend WithEvents CheckSodio As System.Windows.Forms.CheckBox
    Friend WithEvents CheckMagnesio As System.Windows.Forms.CheckBox
    Friend WithEvents CheckCalcio As System.Windows.Forms.CheckBox
    Friend WithEvents CheckSB As System.Windows.Forms.CheckBox
    Friend WithEvents CheckCIC As System.Windows.Forms.CheckBox
    Friend WithEvents CheckAcidezT As System.Windows.Forms.CheckBox
End Class
