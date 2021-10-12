<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSubirInformes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSubirInformes))
        Me.TextIdCliente = New System.Windows.Forms.TextBox
        Me.TextNombreCliente = New System.Windows.Forms.TextBox
        Me.ButtonSeleccionarCliente = New System.Windows.Forms.Button
        Me.ButtonSeleccionarFicha = New System.Windows.Forms.Button
        Me.TextFicha = New System.Windows.Forms.TextBox
        Me.CheckXls = New System.Windows.Forms.CheckBox
        Me.CheckPdf = New System.Windows.Forms.CheckBox
        Me.CheckTxt = New System.Windows.Forms.CheckBox
        Me.DateFecha = New System.Windows.Forms.DateTimePicker
        Me.RadioNoAbonadosv = New System.Windows.Forms.RadioButton
        Me.RadioNoAbonadocv = New System.Windows.Forms.RadioButton
        Me.RadioAbonado = New System.Windows.Forms.RadioButton
        Me.TextComentarios = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ButtonEnviarCopia = New System.Windows.Forms.Button
        Me.TextEnviarCopia = New System.Windows.Forms.TextBox
        Me.CheckCom = New System.Windows.Forms.CheckBox
        Me.CheckComUy = New System.Windows.Forms.CheckBox
        Me.ButtonSubirInforme = New System.Windows.Forms.Button
        Me.TextTipoAnalisis = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'TextIdCliente
        '
        Me.TextIdCliente.Location = New System.Drawing.Point(12, 69)
        Me.TextIdCliente.Name = "TextIdCliente"
        Me.TextIdCliente.ReadOnly = True
        Me.TextIdCliente.Size = New System.Drawing.Size(100, 20)
        Me.TextIdCliente.TabIndex = 0
        '
        'TextNombreCliente
        '
        Me.TextNombreCliente.Location = New System.Drawing.Point(118, 69)
        Me.TextNombreCliente.Name = "TextNombreCliente"
        Me.TextNombreCliente.ReadOnly = True
        Me.TextNombreCliente.Size = New System.Drawing.Size(315, 20)
        Me.TextNombreCliente.TabIndex = 1
        '
        'ButtonSeleccionarCliente
        '
        Me.ButtonSeleccionarCliente.Location = New System.Drawing.Point(12, 40)
        Me.ButtonSeleccionarCliente.Name = "ButtonSeleccionarCliente"
        Me.ButtonSeleccionarCliente.Size = New System.Drawing.Size(107, 23)
        Me.ButtonSeleccionarCliente.TabIndex = 2
        Me.ButtonSeleccionarCliente.Text = "Seleccionar cliente"
        Me.ButtonSeleccionarCliente.UseVisualStyleBackColor = True
        '
        'ButtonSeleccionarFicha
        '
        Me.ButtonSeleccionarFicha.Location = New System.Drawing.Point(12, 95)
        Me.ButtonSeleccionarFicha.Name = "ButtonSeleccionarFicha"
        Me.ButtonSeleccionarFicha.Size = New System.Drawing.Size(107, 23)
        Me.ButtonSeleccionarFicha.TabIndex = 3
        Me.ButtonSeleccionarFicha.Text = "Seleccionar ficha"
        Me.ButtonSeleccionarFicha.UseVisualStyleBackColor = True
        '
        'TextFicha
        '
        Me.TextFicha.Location = New System.Drawing.Point(125, 97)
        Me.TextFicha.Name = "TextFicha"
        Me.TextFicha.Size = New System.Drawing.Size(100, 20)
        Me.TextFicha.TabIndex = 4
        '
        'CheckXls
        '
        Me.CheckXls.AutoSize = True
        Me.CheckXls.Location = New System.Drawing.Point(231, 101)
        Me.CheckXls.Name = "CheckXls"
        Me.CheckXls.Size = New System.Drawing.Size(38, 17)
        Me.CheckXls.TabIndex = 5
        Me.CheckXls.Text = "xls"
        Me.CheckXls.UseVisualStyleBackColor = True
        '
        'CheckPdf
        '
        Me.CheckPdf.AutoSize = True
        Me.CheckPdf.Location = New System.Drawing.Point(275, 101)
        Me.CheckPdf.Name = "CheckPdf"
        Me.CheckPdf.Size = New System.Drawing.Size(41, 17)
        Me.CheckPdf.TabIndex = 6
        Me.CheckPdf.Text = "pdf"
        Me.CheckPdf.UseVisualStyleBackColor = True
        '
        'CheckTxt
        '
        Me.CheckTxt.AutoSize = True
        Me.CheckTxt.Location = New System.Drawing.Point(322, 101)
        Me.CheckTxt.Name = "CheckTxt"
        Me.CheckTxt.Size = New System.Drawing.Size(37, 17)
        Me.CheckTxt.TabIndex = 7
        Me.CheckTxt.Text = "txt"
        Me.CheckTxt.UseVisualStyleBackColor = True
        '
        'DateFecha
        '
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(12, 12)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(104, 20)
        Me.DateFecha.TabIndex = 8
        '
        'RadioNoAbonadosv
        '
        Me.RadioNoAbonadosv.AutoSize = True
        Me.RadioNoAbonadosv.Location = New System.Drawing.Point(12, 157)
        Me.RadioNoAbonadosv.Name = "RadioNoAbonadosv"
        Me.RadioNoAbonadosv.Size = New System.Drawing.Size(169, 17)
        Me.RadioNoAbonadosv.TabIndex = 9
        Me.RadioNoAbonadosv.TabStop = True
        Me.RadioNoAbonadosv.Text = "No abonado (sin visualización)"
        Me.RadioNoAbonadosv.UseVisualStyleBackColor = True
        '
        'RadioNoAbonadocv
        '
        Me.RadioNoAbonadocv.AutoSize = True
        Me.RadioNoAbonadocv.Location = New System.Drawing.Point(12, 180)
        Me.RadioNoAbonadocv.Name = "RadioNoAbonadocv"
        Me.RadioNoAbonadocv.Size = New System.Drawing.Size(174, 17)
        Me.RadioNoAbonadocv.TabIndex = 10
        Me.RadioNoAbonadocv.TabStop = True
        Me.RadioNoAbonadocv.Text = "No abonado (con visualización)"
        Me.RadioNoAbonadocv.UseVisualStyleBackColor = True
        '
        'RadioAbonado
        '
        Me.RadioAbonado.AutoSize = True
        Me.RadioAbonado.Location = New System.Drawing.Point(12, 203)
        Me.RadioAbonado.Name = "RadioAbonado"
        Me.RadioAbonado.Size = New System.Drawing.Size(68, 17)
        Me.RadioAbonado.TabIndex = 11
        Me.RadioAbonado.TabStop = True
        Me.RadioAbonado.Text = "Abonado"
        Me.RadioAbonado.UseVisualStyleBackColor = True
        '
        'TextComentarios
        '
        Me.TextComentarios.Location = New System.Drawing.Point(12, 251)
        Me.TextComentarios.Multiline = True
        Me.TextComentarios.Name = "TextComentarios"
        Me.TextComentarios.Size = New System.Drawing.Size(278, 79)
        Me.TextComentarios.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 235)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Comentarios:"
        '
        'ButtonEnviarCopia
        '
        Me.ButtonEnviarCopia.Location = New System.Drawing.Point(12, 348)
        Me.ButtonEnviarCopia.Name = "ButtonEnviarCopia"
        Me.ButtonEnviarCopia.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEnviarCopia.TabIndex = 14
        Me.ButtonEnviarCopia.Text = "Enviar copia"
        Me.ButtonEnviarCopia.UseVisualStyleBackColor = True
        '
        'TextEnviarCopia
        '
        Me.TextEnviarCopia.Location = New System.Drawing.Point(12, 377)
        Me.TextEnviarCopia.Name = "TextEnviarCopia"
        Me.TextEnviarCopia.Size = New System.Drawing.Size(278, 20)
        Me.TextEnviarCopia.TabIndex = 15
        '
        'CheckCom
        '
        Me.CheckCom.AutoSize = True
        Me.CheckCom.Location = New System.Drawing.Point(12, 403)
        Me.CheckCom.Name = "CheckCom"
        Me.CheckCom.Size = New System.Drawing.Size(165, 17)
        Me.CheckCom.TabIndex = 16
        Me.CheckCom.Text = "http://www.colaveco.com.uy"
        Me.CheckCom.UseVisualStyleBackColor = True
        '
        'CheckComUy
        '
        Me.CheckComUy.AutoSize = True
        Me.CheckComUy.Location = New System.Drawing.Point(12, 426)
        Me.CheckComUy.Name = "CheckComUy"
        Me.CheckComUy.Size = New System.Drawing.Size(165, 17)
        Me.CheckComUy.TabIndex = 17
        Me.CheckComUy.Text = "http://www.colaveco.com.uy"
        Me.CheckComUy.UseVisualStyleBackColor = True
        Me.CheckComUy.Visible = False
        '
        'ButtonSubirInforme
        '
        Me.ButtonSubirInforme.Location = New System.Drawing.Point(339, 426)
        Me.ButtonSubirInforme.Name = "ButtonSubirInforme"
        Me.ButtonSubirInforme.Size = New System.Drawing.Size(94, 23)
        Me.ButtonSubirInforme.TabIndex = 18
        Me.ButtonSubirInforme.Text = "Subir informe"
        Me.ButtonSubirInforme.UseVisualStyleBackColor = True
        '
        'TextTipoAnalisis
        '
        Me.TextTipoAnalisis.Location = New System.Drawing.Point(12, 124)
        Me.TextTipoAnalisis.Name = "TextTipoAnalisis"
        Me.TextTipoAnalisis.ReadOnly = True
        Me.TextTipoAnalisis.Size = New System.Drawing.Size(324, 20)
        Me.TextTipoAnalisis.TabIndex = 19
        '
        'FormSubirInformes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(439, 456)
        Me.Controls.Add(Me.TextTipoAnalisis)
        Me.Controls.Add(Me.ButtonSubirInforme)
        Me.Controls.Add(Me.CheckComUy)
        Me.Controls.Add(Me.CheckCom)
        Me.Controls.Add(Me.TextEnviarCopia)
        Me.Controls.Add(Me.ButtonEnviarCopia)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextComentarios)
        Me.Controls.Add(Me.RadioAbonado)
        Me.Controls.Add(Me.RadioNoAbonadocv)
        Me.Controls.Add(Me.RadioNoAbonadosv)
        Me.Controls.Add(Me.DateFecha)
        Me.Controls.Add(Me.CheckTxt)
        Me.Controls.Add(Me.CheckPdf)
        Me.Controls.Add(Me.CheckXls)
        Me.Controls.Add(Me.TextFicha)
        Me.Controls.Add(Me.ButtonSeleccionarFicha)
        Me.Controls.Add(Me.ButtonSeleccionarCliente)
        Me.Controls.Add(Me.TextNombreCliente)
        Me.Controls.Add(Me.TextIdCliente)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormSubirInformes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Subir informes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextIdCliente As System.Windows.Forms.TextBox
    Friend WithEvents TextNombreCliente As System.Windows.Forms.TextBox
    Friend WithEvents ButtonSeleccionarCliente As System.Windows.Forms.Button
    Friend WithEvents ButtonSeleccionarFicha As System.Windows.Forms.Button
    Friend WithEvents TextFicha As System.Windows.Forms.TextBox
    Friend WithEvents CheckXls As System.Windows.Forms.CheckBox
    Friend WithEvents CheckPdf As System.Windows.Forms.CheckBox
    Friend WithEvents CheckTxt As System.Windows.Forms.CheckBox
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents RadioNoAbonadosv As System.Windows.Forms.RadioButton
    Friend WithEvents RadioNoAbonadocv As System.Windows.Forms.RadioButton
    Friend WithEvents RadioAbonado As System.Windows.Forms.RadioButton
    Friend WithEvents TextComentarios As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonEnviarCopia As System.Windows.Forms.Button
    Friend WithEvents TextEnviarCopia As System.Windows.Forms.TextBox
    Friend WithEvents CheckCom As System.Windows.Forms.CheckBox
    Friend WithEvents CheckComUy As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonSubirInforme As System.Windows.Forms.Button
    Friend WithEvents TextTipoAnalisis As System.Windows.Forms.TextBox
End Class
