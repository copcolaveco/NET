<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSubirGestor
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
        Me.TextFicha = New System.Windows.Forms.TextBox()
        Me.ButtonSubir = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ButtonExcel = New System.Windows.Forms.Button()
        Me.TextXls = New System.Windows.Forms.TextBox()
        Me.ButtonPdf = New System.Windows.Forms.Button()
        Me.TextPdf = New System.Windows.Forms.TextBox()
        Me.TextTxt = New System.Windows.Forms.TextBox()
        Me.ButtonTxt = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextComentarios = New System.Windows.Forms.TextBox()
        Me.RadioAbonado = New System.Windows.Forms.RadioButton()
        Me.RadioNoAbonadocv = New System.Windows.Forms.RadioButton()
        Me.RadioNoAbonadosv = New System.Windows.Forms.RadioButton()
        Me.DateFecha = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'TextFicha
        '
        Me.TextFicha.Location = New System.Drawing.Point(16, 25)
        Me.TextFicha.Name = "TextFicha"
        Me.TextFicha.Size = New System.Drawing.Size(71, 20)
        Me.TextFicha.TabIndex = 3
        '
        'ButtonSubir
        '
        Me.ButtonSubir.Location = New System.Drawing.Point(267, 411)
        Me.ButtonSubir.Name = "ButtonSubir"
        Me.ButtonSubir.Size = New System.Drawing.Size(71, 23)
        Me.ButtonSubir.TabIndex = 4
        Me.ButtonSubir.Text = "Subir"
        Me.ButtonSubir.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Nº Ficha"
        '
        'ButtonExcel
        '
        Me.ButtonExcel.Location = New System.Drawing.Point(15, 51)
        Me.ButtonExcel.Name = "ButtonExcel"
        Me.ButtonExcel.Size = New System.Drawing.Size(75, 23)
        Me.ButtonExcel.TabIndex = 8
        Me.ButtonExcel.Text = "Excel"
        Me.ButtonExcel.UseVisualStyleBackColor = True
        '
        'TextXls
        '
        Me.TextXls.Location = New System.Drawing.Point(15, 80)
        Me.TextXls.Name = "TextXls"
        Me.TextXls.Size = New System.Drawing.Size(320, 20)
        Me.TextXls.TabIndex = 9
        '
        'ButtonPdf
        '
        Me.ButtonPdf.Location = New System.Drawing.Point(15, 106)
        Me.ButtonPdf.Name = "ButtonPdf"
        Me.ButtonPdf.Size = New System.Drawing.Size(75, 23)
        Me.ButtonPdf.TabIndex = 10
        Me.ButtonPdf.Text = "Pdf"
        Me.ButtonPdf.UseVisualStyleBackColor = True
        '
        'TextPdf
        '
        Me.TextPdf.Location = New System.Drawing.Point(15, 135)
        Me.TextPdf.Name = "TextPdf"
        Me.TextPdf.Size = New System.Drawing.Size(320, 20)
        Me.TextPdf.TabIndex = 11
        '
        'TextTxt
        '
        Me.TextTxt.Location = New System.Drawing.Point(15, 190)
        Me.TextTxt.Name = "TextTxt"
        Me.TextTxt.Size = New System.Drawing.Size(320, 20)
        Me.TextTxt.TabIndex = 12
        '
        'ButtonTxt
        '
        Me.ButtonTxt.Location = New System.Drawing.Point(15, 161)
        Me.ButtonTxt.Name = "ButtonTxt"
        Me.ButtonTxt.Size = New System.Drawing.Size(75, 23)
        Me.ButtonTxt.TabIndex = 13
        Me.ButtonTxt.Text = "Txt"
        Me.ButtonTxt.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 301)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "Comentarios:"
        '
        'TextComentarios
        '
        Me.TextComentarios.Location = New System.Drawing.Point(15, 317)
        Me.TextComentarios.Multiline = True
        Me.TextComentarios.Name = "TextComentarios"
        Me.TextComentarios.Size = New System.Drawing.Size(278, 79)
        Me.TextComentarios.TabIndex = 37
        '
        'RadioAbonado
        '
        Me.RadioAbonado.AutoSize = True
        Me.RadioAbonado.Location = New System.Drawing.Point(15, 269)
        Me.RadioAbonado.Name = "RadioAbonado"
        Me.RadioAbonado.Size = New System.Drawing.Size(68, 17)
        Me.RadioAbonado.TabIndex = 36
        Me.RadioAbonado.TabStop = True
        Me.RadioAbonado.Text = "Abonado"
        Me.RadioAbonado.UseVisualStyleBackColor = True
        '
        'RadioNoAbonadocv
        '
        Me.RadioNoAbonadocv.AutoSize = True
        Me.RadioNoAbonadocv.Location = New System.Drawing.Point(15, 246)
        Me.RadioNoAbonadocv.Name = "RadioNoAbonadocv"
        Me.RadioNoAbonadocv.Size = New System.Drawing.Size(174, 17)
        Me.RadioNoAbonadocv.TabIndex = 35
        Me.RadioNoAbonadocv.TabStop = True
        Me.RadioNoAbonadocv.Text = "No abonado (con visualización)"
        Me.RadioNoAbonadocv.UseVisualStyleBackColor = True
        '
        'RadioNoAbonadosv
        '
        Me.RadioNoAbonadosv.AutoSize = True
        Me.RadioNoAbonadosv.Location = New System.Drawing.Point(15, 223)
        Me.RadioNoAbonadosv.Name = "RadioNoAbonadosv"
        Me.RadioNoAbonadosv.Size = New System.Drawing.Size(169, 17)
        Me.RadioNoAbonadosv.TabIndex = 34
        Me.RadioNoAbonadosv.TabStop = True
        Me.RadioNoAbonadosv.Text = "No abonado (sin visualización)"
        Me.RadioNoAbonadosv.UseVisualStyleBackColor = True
        '
        'DateFecha
        '
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(233, 9)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(105, 20)
        Me.DateFecha.TabIndex = 39
        '
        'FormSubirGestor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(347, 449)
        Me.Controls.Add(Me.DateFecha)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextComentarios)
        Me.Controls.Add(Me.RadioAbonado)
        Me.Controls.Add(Me.RadioNoAbonadocv)
        Me.Controls.Add(Me.RadioNoAbonadosv)
        Me.Controls.Add(Me.ButtonTxt)
        Me.Controls.Add(Me.TextTxt)
        Me.Controls.Add(Me.TextPdf)
        Me.Controls.Add(Me.ButtonPdf)
        Me.Controls.Add(Me.TextXls)
        Me.Controls.Add(Me.ButtonExcel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ButtonSubir)
        Me.Controls.Add(Me.TextFicha)
        Me.Name = "FormSubirGestor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Subir informes al Gestor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextFicha As System.Windows.Forms.TextBox
    Friend WithEvents ButtonSubir As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ButtonExcel As System.Windows.Forms.Button
    Friend WithEvents TextXls As System.Windows.Forms.TextBox
    Friend WithEvents ButtonPdf As System.Windows.Forms.Button
    Friend WithEvents TextPdf As System.Windows.Forms.TextBox
    Friend WithEvents TextTxt As System.Windows.Forms.TextBox
    Friend WithEvents ButtonTxt As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextComentarios As System.Windows.Forms.TextBox
    Friend WithEvents RadioAbonado As System.Windows.Forms.RadioButton
    Friend WithEvents RadioNoAbonadocv As System.Windows.Forms.RadioButton
    Friend WithEvents RadioNoAbonadosv As System.Windows.Forms.RadioButton
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
End Class
