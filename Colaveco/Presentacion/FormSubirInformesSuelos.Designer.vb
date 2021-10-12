<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSubirInformesSuelos
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
        Me.ButtonSubirInforme = New System.Windows.Forms.Button
        Me.TextEnviarCopia = New System.Windows.Forms.TextBox
        Me.ButtonEnviarCopia = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextComentarios = New System.Windows.Forms.TextBox
        Me.RadioAbonado = New System.Windows.Forms.RadioButton
        Me.RadioNoAbonadocv = New System.Windows.Forms.RadioButton
        Me.RadioNoAbonadosv = New System.Windows.Forms.RadioButton
        Me.DateFecha = New System.Windows.Forms.DateTimePicker
        Me.SuspendLayout()
        '
        'ButtonSubirInforme
        '
        Me.ButtonSubirInforme.Location = New System.Drawing.Point(12, 296)
        Me.ButtonSubirInforme.Name = "ButtonSubirInforme"
        Me.ButtonSubirInforme.Size = New System.Drawing.Size(94, 23)
        Me.ButtonSubirInforme.TabIndex = 38
        Me.ButtonSubirInforme.Text = "Subir informe"
        Me.ButtonSubirInforme.UseVisualStyleBackColor = True
        '
        'TextEnviarCopia
        '
        Me.TextEnviarCopia.Location = New System.Drawing.Point(12, 258)
        Me.TextEnviarCopia.Name = "TextEnviarCopia"
        Me.TextEnviarCopia.Size = New System.Drawing.Size(278, 20)
        Me.TextEnviarCopia.TabIndex = 35
        '
        'ButtonEnviarCopia
        '
        Me.ButtonEnviarCopia.Location = New System.Drawing.Point(12, 229)
        Me.ButtonEnviarCopia.Name = "ButtonEnviarCopia"
        Me.ButtonEnviarCopia.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEnviarCopia.TabIndex = 34
        Me.ButtonEnviarCopia.Text = "Enviar copia"
        Me.ButtonEnviarCopia.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 116)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Comentarios:"
        '
        'TextComentarios
        '
        Me.TextComentarios.Location = New System.Drawing.Point(12, 132)
        Me.TextComentarios.Multiline = True
        Me.TextComentarios.Name = "TextComentarios"
        Me.TextComentarios.Size = New System.Drawing.Size(278, 79)
        Me.TextComentarios.TabIndex = 32
        '
        'RadioAbonado
        '
        Me.RadioAbonado.AutoSize = True
        Me.RadioAbonado.Location = New System.Drawing.Point(12, 84)
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
        Me.RadioNoAbonadocv.Location = New System.Drawing.Point(12, 61)
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
        Me.RadioNoAbonadosv.Location = New System.Drawing.Point(12, 38)
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
        'FormSubirInformesSuelos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(308, 344)
        Me.Controls.Add(Me.ButtonSubirInforme)
        Me.Controls.Add(Me.TextEnviarCopia)
        Me.Controls.Add(Me.ButtonEnviarCopia)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextComentarios)
        Me.Controls.Add(Me.RadioAbonado)
        Me.Controls.Add(Me.RadioNoAbonadocv)
        Me.Controls.Add(Me.RadioNoAbonadosv)
        Me.Controls.Add(Me.DateFecha)
        Me.Name = "FormSubirInformesSuelos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Subir informes de suelos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonSubirInforme As System.Windows.Forms.Button
    Friend WithEvents TextEnviarCopia As System.Windows.Forms.TextBox
    Friend WithEvents ButtonEnviarCopia As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextComentarios As System.Windows.Forms.TextBox
    Friend WithEvents RadioAbonado As System.Windows.Forms.RadioButton
    Friend WithEvents RadioNoAbonadocv As System.Windows.Forms.RadioButton
    Friend WithEvents RadioNoAbonadosv As System.Windows.Forms.RadioButton
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
End Class
