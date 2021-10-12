<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSubirInformes2
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
        Me.TextTipoAnalisis = New System.Windows.Forms.TextBox
        Me.ButtonSubirInforme = New System.Windows.Forms.Button
        Me.CheckCom = New System.Windows.Forms.CheckBox
        Me.TextEnviarCopia = New System.Windows.Forms.TextBox
        Me.ButtonEnviarCopia = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextComentarios = New System.Windows.Forms.TextBox
        Me.RadioAbonado = New System.Windows.Forms.RadioButton
        Me.RadioNoAbonadocv = New System.Windows.Forms.RadioButton
        Me.RadioNoAbonadosv = New System.Windows.Forms.RadioButton
        Me.DateFecha = New System.Windows.Forms.DateTimePicker
        Me.CheckTxt = New System.Windows.Forms.CheckBox
        Me.CheckPdf = New System.Windows.Forms.CheckBox
        Me.CheckXls = New System.Windows.Forms.CheckBox
        Me.TextFicha = New System.Windows.Forms.TextBox
        Me.ButtonSeleccionarFicha = New System.Windows.Forms.Button
        Me.ButtonSeleccionarCliente = New System.Windows.Forms.Button
        Me.TextNombreCliente = New System.Windows.Forms.TextBox
        Me.TextIdCliente = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'TextTipoAnalisis
        '
        Me.TextTipoAnalisis.Location = New System.Drawing.Point(12, 124)
        Me.TextTipoAnalisis.Name = "TextTipoAnalisis"
        Me.TextTipoAnalisis.ReadOnly = True
        Me.TextTipoAnalisis.Size = New System.Drawing.Size(324, 20)
        Me.TextTipoAnalisis.TabIndex = 39
        '
        'ButtonSubirInforme
        '
        Me.ButtonSubirInforme.Location = New System.Drawing.Point(339, 426)
        Me.ButtonSubirInforme.Name = "ButtonSubirInforme"
        Me.ButtonSubirInforme.Size = New System.Drawing.Size(94, 23)
        Me.ButtonSubirInforme.TabIndex = 38
        Me.ButtonSubirInforme.Text = "Subir informe"
        Me.ButtonSubirInforme.UseVisualStyleBackColor = True
        '
        'CheckCom
        '
        Me.CheckCom.AutoSize = True
        Me.CheckCom.Location = New System.Drawing.Point(12, 403)
        Me.CheckCom.Name = "CheckCom"
        Me.CheckCom.Size = New System.Drawing.Size(151, 17)
        Me.CheckCom.TabIndex = 36
        Me.CheckCom.Text = "http://www.colaveco.com.uy"
        Me.CheckCom.UseVisualStyleBackColor = True
        '
        'TextEnviarCopia
        '
        Me.TextEnviarCopia.Location = New System.Drawing.Point(12, 377)
        Me.TextEnviarCopia.Name = "TextEnviarCopia"
        Me.TextEnviarCopia.Size = New System.Drawing.Size(278, 20)
        Me.TextEnviarCopia.TabIndex = 35
        '
        'ButtonEnviarCopia
        '
        Me.ButtonEnviarCopia.Location = New System.Drawing.Point(12, 348)
        Me.ButtonEnviarCopia.Name = "ButtonEnviarCopia"
        Me.ButtonEnviarCopia.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEnviarCopia.TabIndex = 34
        Me.ButtonEnviarCopia.Text = "Enviar copia"
        Me.ButtonEnviarCopia.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 235)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Comentarios:"
        '
        'TextComentarios
        '
        Me.TextComentarios.Location = New System.Drawing.Point(12, 251)
        Me.TextComentarios.Multiline = True
        Me.TextComentarios.Name = "TextComentarios"
        Me.TextComentarios.Size = New System.Drawing.Size(278, 79)
        Me.TextComentarios.TabIndex = 32
        '
        'RadioAbonado
        '
        Me.RadioAbonado.AutoSize = True
        Me.RadioAbonado.Location = New System.Drawing.Point(12, 203)
        Me.RadioAbonado.Name = "RadioAbonado"
        Me.RadioAbonado.Size = New System.Drawing.Size(68, 17)
        Me.RadioAbonado.TabIndex = 31
        Me.RadioAbonado.TabStop = True
        Me.RadioAbonado.Text = "Abonado"
        Me.RadioAbonado.UseVisualStyleBackColor = True
        '
        'RadioNoAbonadocv
        '
        Me.RadioNoAbonadocv.AutoSize = True
        Me.RadioNoAbonadocv.Location = New System.Drawing.Point(12, 180)
        Me.RadioNoAbonadocv.Name = "RadioNoAbonadocv"
        Me.RadioNoAbonadocv.Size = New System.Drawing.Size(174, 17)
        Me.RadioNoAbonadocv.TabIndex = 30
        Me.RadioNoAbonadocv.TabStop = True
        Me.RadioNoAbonadocv.Text = "No abonado (con visualización)"
        Me.RadioNoAbonadocv.UseVisualStyleBackColor = True
        '
        'RadioNoAbonadosv
        '
        Me.RadioNoAbonadosv.AutoSize = True
        Me.RadioNoAbonadosv.Location = New System.Drawing.Point(12, 157)
        Me.RadioNoAbonadosv.Name = "RadioNoAbonadosv"
        Me.RadioNoAbonadosv.Size = New System.Drawing.Size(169, 17)
        Me.RadioNoAbonadosv.TabIndex = 29
        Me.RadioNoAbonadosv.TabStop = True
        Me.RadioNoAbonadosv.Text = "No abonado (sin visualización)"
        Me.RadioNoAbonadosv.UseVisualStyleBackColor = True
        '
        'DateFecha
        '
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(12, 12)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(104, 20)
        Me.DateFecha.TabIndex = 28
        '
        'CheckTxt
        '
        Me.CheckTxt.AutoSize = True
        Me.CheckTxt.Location = New System.Drawing.Point(322, 101)
        Me.CheckTxt.Name = "CheckTxt"
        Me.CheckTxt.Size = New System.Drawing.Size(37, 17)
        Me.CheckTxt.TabIndex = 27
        Me.CheckTxt.Text = "txt"
        Me.CheckTxt.UseVisualStyleBackColor = True
        '
        'CheckPdf
        '
        Me.CheckPdf.AutoSize = True
        Me.CheckPdf.Location = New System.Drawing.Point(275, 101)
        Me.CheckPdf.Name = "CheckPdf"
        Me.CheckPdf.Size = New System.Drawing.Size(41, 17)
        Me.CheckPdf.TabIndex = 26
        Me.CheckPdf.Text = "pdf"
        Me.CheckPdf.UseVisualStyleBackColor = True
        '
        'CheckXls
        '
        Me.CheckXls.AutoSize = True
        Me.CheckXls.Location = New System.Drawing.Point(231, 101)
        Me.CheckXls.Name = "CheckXls"
        Me.CheckXls.Size = New System.Drawing.Size(38, 17)
        Me.CheckXls.TabIndex = 25
        Me.CheckXls.Text = "xls"
        Me.CheckXls.UseVisualStyleBackColor = True
        '
        'TextFicha
        '
        Me.TextFicha.Location = New System.Drawing.Point(125, 97)
        Me.TextFicha.Name = "TextFicha"
        Me.TextFicha.Size = New System.Drawing.Size(100, 20)
        Me.TextFicha.TabIndex = 24
        '
        'ButtonSeleccionarFicha
        '
        Me.ButtonSeleccionarFicha.Location = New System.Drawing.Point(12, 95)
        Me.ButtonSeleccionarFicha.Name = "ButtonSeleccionarFicha"
        Me.ButtonSeleccionarFicha.Size = New System.Drawing.Size(107, 23)
        Me.ButtonSeleccionarFicha.TabIndex = 23
        Me.ButtonSeleccionarFicha.Text = "Seleccionar ficha"
        Me.ButtonSeleccionarFicha.UseVisualStyleBackColor = True
        '
        'ButtonSeleccionarCliente
        '
        Me.ButtonSeleccionarCliente.Location = New System.Drawing.Point(12, 40)
        Me.ButtonSeleccionarCliente.Name = "ButtonSeleccionarCliente"
        Me.ButtonSeleccionarCliente.Size = New System.Drawing.Size(107, 23)
        Me.ButtonSeleccionarCliente.TabIndex = 22
        Me.ButtonSeleccionarCliente.Text = "Seleccionar cliente"
        Me.ButtonSeleccionarCliente.UseVisualStyleBackColor = True
        '
        'TextNombreCliente
        '
        Me.TextNombreCliente.Location = New System.Drawing.Point(118, 69)
        Me.TextNombreCliente.Name = "TextNombreCliente"
        Me.TextNombreCliente.ReadOnly = True
        Me.TextNombreCliente.Size = New System.Drawing.Size(315, 20)
        Me.TextNombreCliente.TabIndex = 21
        '
        'TextIdCliente
        '
        Me.TextIdCliente.Location = New System.Drawing.Point(12, 69)
        Me.TextIdCliente.Name = "TextIdCliente"
        Me.TextIdCliente.ReadOnly = True
        Me.TextIdCliente.Size = New System.Drawing.Size(100, 20)
        Me.TextIdCliente.TabIndex = 20
        '
        'FormSubirInformes2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(452, 461)
        Me.Controls.Add(Me.TextTipoAnalisis)
        Me.Controls.Add(Me.ButtonSubirInforme)
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
        Me.Name = "FormSubirInformes2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Subir Informes (Nuevo)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextTipoAnalisis As System.Windows.Forms.TextBox
    Friend WithEvents ButtonSubirInforme As System.Windows.Forms.Button
    Friend WithEvents CheckCom As System.Windows.Forms.CheckBox
    Friend WithEvents TextEnviarCopia As System.Windows.Forms.TextBox
    Friend WithEvents ButtonEnviarCopia As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextComentarios As System.Windows.Forms.TextBox
    Friend WithEvents RadioAbonado As System.Windows.Forms.RadioButton
    Friend WithEvents RadioNoAbonadocv As System.Windows.Forms.RadioButton
    Friend WithEvents RadioNoAbonadosv As System.Windows.Forms.RadioButton
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents CheckTxt As System.Windows.Forms.CheckBox
    Friend WithEvents CheckPdf As System.Windows.Forms.CheckBox
    Friend WithEvents CheckXls As System.Windows.Forms.CheckBox
    Friend WithEvents TextFicha As System.Windows.Forms.TextBox
    Friend WithEvents ButtonSeleccionarFicha As System.Windows.Forms.Button
    Friend WithEvents ButtonSeleccionarCliente As System.Windows.Forms.Button
    Friend WithEvents TextNombreCliente As System.Windows.Forms.TextBox
    Friend WithEvents TextIdCliente As System.Windows.Forms.TextBox
End Class
