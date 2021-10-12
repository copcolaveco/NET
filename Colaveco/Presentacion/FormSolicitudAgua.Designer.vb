<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSolicitudAgua
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSolicitudAgua))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextAntiguedad = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextProfundidad = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TextDistTambo = New System.Windows.Forms.TextBox
        Me.TextDistPozoNegro = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.ComboIdTipoPozo = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.ComboIdEstConsevacion = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.ComboIdMuestraExtraida = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.ComboIdMuestFueraCondicion = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.ComboIdAguaTratada = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.ButtonGuardar = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.CheckEcoli = New System.Windows.Forms.CheckBox
        Me.CheckCondyPH = New System.Windows.Forms.CheckBox
        Me.CheckCloro = New System.Windows.Forms.CheckBox
        Me.CheckHeterotroficos37 = New System.Windows.Forms.CheckBox
        Me.CheckHeterotroficos35 = New System.Windows.Forms.CheckBox
        Me.CheckHeterotroficos22 = New System.Windows.Forms.CheckBox
        Me.CheckMuestraOficial = New System.Windows.Forms.CheckBox
        Me.CheckSulfitoReductores = New System.Windows.Forms.CheckBox
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(105, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Datos del pozo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(401, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Datos de la muestra"
        '
        'TextAntiguedad
        '
        Me.TextAntiguedad.Location = New System.Drawing.Point(161, 116)
        Me.TextAntiguedad.Name = "TextAntiguedad"
        Me.TextAntiguedad.Size = New System.Drawing.Size(45, 20)
        Me.TextAntiguedad.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(33, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Antigüedad"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(212, 119)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "años"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(33, 145)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Profundidad"
        '
        'TextProfundidad
        '
        Me.TextProfundidad.Location = New System.Drawing.Point(161, 142)
        Me.TextProfundidad.Name = "TextProfundidad"
        Me.TextProfundidad.Size = New System.Drawing.Size(45, 20)
        Me.TextProfundidad.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(212, 145)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "mts."
        '
        'TextDistTambo
        '
        Me.TextDistTambo.Location = New System.Drawing.Point(161, 168)
        Me.TextDistTambo.Name = "TextDistTambo"
        Me.TextDistTambo.Size = New System.Drawing.Size(45, 20)
        Me.TextDistTambo.TabIndex = 4
        '
        'TextDistPozoNegro
        '
        Me.TextDistPozoNegro.Location = New System.Drawing.Point(161, 194)
        Me.TextDistPozoNegro.Name = "TextDistPozoNegro"
        Me.TextDistPozoNegro.Size = New System.Drawing.Size(45, 20)
        Me.TextDistPozoNegro.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(33, 171)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Distancia al tambo"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(33, 197)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(118, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Distancia al pozo negro"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(212, 171)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(26, 13)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "mts."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(212, 197)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(26, 13)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "mts."
        '
        'ComboIdTipoPozo
        '
        Me.ComboIdTipoPozo.FormattingEnabled = True
        Me.ComboIdTipoPozo.Location = New System.Drawing.Point(161, 62)
        Me.ComboIdTipoPozo.Name = "ComboIdTipoPozo"
        Me.ComboIdTipoPozo.Size = New System.Drawing.Size(131, 21)
        Me.ComboIdTipoPozo.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(33, 65)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 13)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "Tipo de pozo"
        '
        'ComboIdEstConsevacion
        '
        Me.ComboIdEstConsevacion.FormattingEnabled = True
        Me.ComboIdEstConsevacion.Location = New System.Drawing.Point(161, 89)
        Me.ComboIdEstConsevacion.Name = "ComboIdEstConsevacion"
        Me.ComboIdEstConsevacion.Size = New System.Drawing.Size(131, 21)
        Me.ComboIdEstConsevacion.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(33, 92)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(122, 13)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "Estado de conservación"
        '
        'ComboIdMuestraExtraida
        '
        Me.ComboIdMuestraExtraida.FormattingEnabled = True
        Me.ComboIdMuestraExtraida.Location = New System.Drawing.Point(447, 84)
        Me.ComboIdMuestraExtraida.Name = "ComboIdMuestraExtraida"
        Me.ComboIdMuestraExtraida.Size = New System.Drawing.Size(131, 21)
        Me.ComboIdMuestraExtraida.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(309, 87)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(105, 13)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "Muestra extraída de:"
        '
        'ComboIdMuestFueraCondicion
        '
        Me.ComboIdMuestFueraCondicion.FormattingEnabled = True
        Me.ComboIdMuestFueraCondicion.Location = New System.Drawing.Point(447, 111)
        Me.ComboIdMuestFueraCondicion.Name = "ComboIdMuestFueraCondicion"
        Me.ComboIdMuestFueraCondicion.Size = New System.Drawing.Size(186, 21)
        Me.ComboIdMuestFueraCondicion.TabIndex = 7
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(309, 114)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(136, 13)
        Me.Label14.TabIndex = 21
        Me.Label14.Text = "Muestra fuera de condición"
        '
        'ComboIdAguaTratada
        '
        Me.ComboIdAguaTratada.FormattingEnabled = True
        Me.ComboIdAguaTratada.Location = New System.Drawing.Point(447, 138)
        Me.ComboIdAguaTratada.Name = "ComboIdAguaTratada"
        Me.ComboIdAguaTratada.Size = New System.Drawing.Size(131, 21)
        Me.ComboIdAguaTratada.TabIndex = 8
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(309, 141)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(68, 13)
        Me.Label15.TabIndex = 23
        Me.Label15.Text = "Agua tratada"
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(538, 313)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(95, 23)
        Me.ButtonGuardar.TabIndex = 10
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CheckSulfitoReductores)
        Me.Panel1.Controls.Add(Me.CheckEcoli)
        Me.Panel1.Controls.Add(Me.CheckCondyPH)
        Me.Panel1.Controls.Add(Me.CheckCloro)
        Me.Panel1.Controls.Add(Me.CheckHeterotroficos37)
        Me.Panel1.Controls.Add(Me.CheckHeterotroficos35)
        Me.Panel1.Controls.Add(Me.CheckHeterotroficos22)
        Me.Panel1.Location = New System.Drawing.Point(312, 179)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(321, 116)
        Me.Panel1.TabIndex = 9
        '
        'CheckEcoli
        '
        Me.CheckEcoli.AutoSize = True
        Me.CheckEcoli.Location = New System.Drawing.Point(194, 60)
        Me.CheckEcoli.Name = "CheckEcoli"
        Me.CheckEcoli.Size = New System.Drawing.Size(49, 17)
        Me.CheckEcoli.TabIndex = 5
        Me.CheckEcoli.Text = "Ecoli"
        Me.CheckEcoli.UseVisualStyleBackColor = True
        '
        'CheckCondyPH
        '
        Me.CheckCondyPH.AutoSize = True
        Me.CheckCondyPH.Location = New System.Drawing.Point(194, 37)
        Me.CheckCondyPH.Name = "CheckCondyPH"
        Me.CheckCondyPH.Size = New System.Drawing.Size(119, 17)
        Me.CheckCondyPH.TabIndex = 4
        Me.CheckCondyPH.Text = "Conductividad / pH"
        Me.CheckCondyPH.UseVisualStyleBackColor = True
        '
        'CheckCloro
        '
        Me.CheckCloro.AutoSize = True
        Me.CheckCloro.Location = New System.Drawing.Point(194, 16)
        Me.CheckCloro.Name = "CheckCloro"
        Me.CheckCloro.Size = New System.Drawing.Size(50, 17)
        Me.CheckCloro.TabIndex = 3
        Me.CheckCloro.Text = "Cloro"
        Me.CheckCloro.UseVisualStyleBackColor = True
        '
        'CheckHeterotroficos37
        '
        Me.CheckHeterotroficos37.AutoSize = True
        Me.CheckHeterotroficos37.Location = New System.Drawing.Point(10, 62)
        Me.CheckHeterotroficos37.Name = "CheckHeterotroficos37"
        Me.CheckHeterotroficos37.Size = New System.Drawing.Size(137, 17)
        Me.CheckHeterotroficos37.TabIndex = 2
        Me.CheckHeterotroficos37.Text = "Heterotróficos 37ºC/mL"
        Me.CheckHeterotroficos37.UseVisualStyleBackColor = True
        '
        'CheckHeterotroficos35
        '
        Me.CheckHeterotroficos35.AutoSize = True
        Me.CheckHeterotroficos35.Location = New System.Drawing.Point(10, 39)
        Me.CheckHeterotroficos35.Name = "CheckHeterotroficos35"
        Me.CheckHeterotroficos35.Size = New System.Drawing.Size(137, 17)
        Me.CheckHeterotroficos35.TabIndex = 1
        Me.CheckHeterotroficos35.Text = "Heterotróficos 35ºC/mL"
        Me.CheckHeterotroficos35.UseVisualStyleBackColor = True
        '
        'CheckHeterotroficos22
        '
        Me.CheckHeterotroficos22.AutoSize = True
        Me.CheckHeterotroficos22.Location = New System.Drawing.Point(10, 16)
        Me.CheckHeterotroficos22.Name = "CheckHeterotroficos22"
        Me.CheckHeterotroficos22.Size = New System.Drawing.Size(137, 17)
        Me.CheckHeterotroficos22.TabIndex = 0
        Me.CheckHeterotroficos22.Text = "Heterotróficos 22ºC/mL"
        Me.CheckHeterotroficos22.UseVisualStyleBackColor = True
        '
        'CheckMuestraOficial
        '
        Me.CheckMuestraOficial.AutoSize = True
        Me.CheckMuestraOficial.Location = New System.Drawing.Point(312, 50)
        Me.CheckMuestraOficial.Name = "CheckMuestraOficial"
        Me.CheckMuestraOficial.Size = New System.Drawing.Size(140, 17)
        Me.CheckMuestraOficial.TabIndex = 24
        Me.CheckMuestraOficial.Text = "Muestra oficial M.G.A.P."
        Me.CheckMuestraOficial.UseVisualStyleBackColor = True
        '
        'CheckSulfitoReductores
        '
        Me.CheckSulfitoReductores.AutoSize = True
        Me.CheckSulfitoReductores.Location = New System.Drawing.Point(10, 85)
        Me.CheckSulfitoReductores.Name = "CheckSulfitoReductores"
        Me.CheckSulfitoReductores.Size = New System.Drawing.Size(108, 17)
        Me.CheckSulfitoReductores.TabIndex = 25
        Me.CheckSulfitoReductores.Text = "Sulfito reductores"
        Me.CheckSulfitoReductores.UseVisualStyleBackColor = True
        '
        'FormSolicitudAgua
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(656, 348)
        Me.ControlBox = False
        Me.Controls.Add(Me.CheckMuestraOficial)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.ComboIdAguaTratada)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.ComboIdMuestFueraCondicion)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.ComboIdMuestraExtraida)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.ComboIdEstConsevacion)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.ComboIdTipoPozo)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextDistPozoNegro)
        Me.Controls.Add(Me.TextDistTambo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextProfundidad)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextAntiguedad)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormSolicitudAgua"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solicitud Agua"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextAntiguedad As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextProfundidad As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextDistTambo As System.Windows.Forms.TextBox
    Friend WithEvents TextDistPozoNegro As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ComboIdTipoPozo As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ComboIdEstConsevacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ComboIdMuestraExtraida As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ComboIdMuestFueraCondicion As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ComboIdAguaTratada As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CheckHeterotroficos37 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckHeterotroficos35 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckHeterotroficos22 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckCondyPH As System.Windows.Forms.CheckBox
    Friend WithEvents CheckCloro As System.Windows.Forms.CheckBox
    Friend WithEvents CheckEcoli As System.Windows.Forms.CheckBox
    Friend WithEvents CheckMuestraOficial As System.Windows.Forms.CheckBox
    Friend WithEvents CheckSulfitoReductores As System.Windows.Forms.CheckBox
End Class
