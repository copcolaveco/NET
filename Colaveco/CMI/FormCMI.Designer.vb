<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCMI
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.MantenimientoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ObjetivosGeneralesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ObjetivosEspecíficosToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ActividadesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ExportarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DataGridDimension = New System.Windows.Forms.DataGridView
        Me.NumericAno = New System.Windows.Forms.NumericUpDown
        Me.DataGridObjGral = New System.Windows.Forms.DataGridView
        Me.DataGridObjEspecifico = New System.Windows.Forms.DataGridView
        Me.DataGridActividades = New System.Windows.Forms.DataGridView
        Me.ButtonMostrar = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DataGridDimension, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericAno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridObjGral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridObjEspecifico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridActividades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Año"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MantenimientoToolStripMenuItem, Me.ObjetivosGeneralesToolStripMenuItem1, Me.ObjetivosEspecíficosToolStripMenuItem1, Me.ActividadesToolStripMenuItem1, Me.ExportarToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1136, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MantenimientoToolStripMenuItem
        '
        Me.MantenimientoToolStripMenuItem.Name = "MantenimientoToolStripMenuItem"
        Me.MantenimientoToolStripMenuItem.Size = New System.Drawing.Size(87, 20)
        Me.MantenimientoToolStripMenuItem.Text = "Dimensiones"
        '
        'ObjetivosGeneralesToolStripMenuItem1
        '
        Me.ObjetivosGeneralesToolStripMenuItem1.Name = "ObjetivosGeneralesToolStripMenuItem1"
        Me.ObjetivosGeneralesToolStripMenuItem1.Size = New System.Drawing.Size(122, 20)
        Me.ObjetivosGeneralesToolStripMenuItem1.Text = "Objetivos generales"
        '
        'ObjetivosEspecíficosToolStripMenuItem1
        '
        Me.ObjetivosEspecíficosToolStripMenuItem1.Name = "ObjetivosEspecíficosToolStripMenuItem1"
        Me.ObjetivosEspecíficosToolStripMenuItem1.Size = New System.Drawing.Size(130, 20)
        Me.ObjetivosEspecíficosToolStripMenuItem1.Text = "Objetivos específicos"
        '
        'ActividadesToolStripMenuItem1
        '
        Me.ActividadesToolStripMenuItem1.Name = "ActividadesToolStripMenuItem1"
        Me.ActividadesToolStripMenuItem1.Size = New System.Drawing.Size(80, 20)
        Me.ActividadesToolStripMenuItem1.Text = "Actividades"
        '
        'ExportarToolStripMenuItem
        '
        Me.ExportarToolStripMenuItem.Name = "ExportarToolStripMenuItem"
        Me.ExportarToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.ExportarToolStripMenuItem.Text = "Exportar"
        '
        'DataGridDimension
        '
        Me.DataGridDimension.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridDimension.Location = New System.Drawing.Point(12, 61)
        Me.DataGridDimension.Name = "DataGridDimension"
        Me.DataGridDimension.RowHeadersVisible = False
        Me.DataGridDimension.Size = New System.Drawing.Size(213, 174)
        Me.DataGridDimension.TabIndex = 5
        '
        'NumericAno
        '
        Me.NumericAno.Location = New System.Drawing.Point(45, 35)
        Me.NumericAno.Maximum = New Decimal(New Integer() {2030, 0, 0, 0})
        Me.NumericAno.Minimum = New Decimal(New Integer() {2013, 0, 0, 0})
        Me.NumericAno.Name = "NumericAno"
        Me.NumericAno.Size = New System.Drawing.Size(64, 20)
        Me.NumericAno.TabIndex = 6
        Me.NumericAno.Value = New Decimal(New Integer() {2013, 0, 0, 0})
        '
        'DataGridObjGral
        '
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridObjGral.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridObjGral.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridObjGral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridObjGral.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridObjGral.Location = New System.Drawing.Point(231, 61)
        Me.DataGridObjGral.Name = "DataGridObjGral"
        Me.DataGridObjGral.RowHeadersVisible = False
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridObjGral.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridObjGral.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridObjGral.Size = New System.Drawing.Size(362, 174)
        Me.DataGridObjGral.TabIndex = 12
        '
        'DataGridObjEspecifico
        '
        Me.DataGridObjEspecifico.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridObjEspecifico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridObjEspecifico.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridObjEspecifico.Location = New System.Drawing.Point(599, 61)
        Me.DataGridObjEspecifico.Name = "DataGridObjEspecifico"
        Me.DataGridObjEspecifico.RowHeadersVisible = False
        Me.DataGridObjEspecifico.Size = New System.Drawing.Size(443, 174)
        Me.DataGridObjEspecifico.TabIndex = 13
        '
        'DataGridActividades
        '
        Me.DataGridActividades.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridActividades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridActividades.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridActividades.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DataGridActividades.Location = New System.Drawing.Point(12, 241)
        Me.DataGridActividades.Name = "DataGridActividades"
        Me.DataGridActividades.RowHeadersVisible = False
        Me.DataGridActividades.Size = New System.Drawing.Size(1112, 375)
        Me.DataGridActividades.TabIndex = 14
        '
        'ButtonMostrar
        '
        Me.ButtonMostrar.Location = New System.Drawing.Point(156, 32)
        Me.ButtonMostrar.Name = "ButtonMostrar"
        Me.ButtonMostrar.Size = New System.Drawing.Size(69, 23)
        Me.ButtonMostrar.TabIndex = 15
        Me.ButtonMostrar.Text = "Actualizar"
        Me.ButtonMostrar.UseVisualStyleBackColor = True
        '
        'FormCMI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1136, 623)
        Me.Controls.Add(Me.ButtonMostrar)
        Me.Controls.Add(Me.DataGridActividades)
        Me.Controls.Add(Me.DataGridObjEspecifico)
        Me.Controls.Add(Me.DataGridObjGral)
        Me.Controls.Add(Me.NumericAno)
        Me.Controls.Add(Me.DataGridDimension)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormCMI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CMI"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DataGridDimension, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericAno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridObjGral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridObjEspecifico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridActividades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MantenimientoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataGridDimension As System.Windows.Forms.DataGridView
    Friend WithEvents NumericAno As System.Windows.Forms.NumericUpDown
    Friend WithEvents DataGridObjGral As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridObjEspecifico As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridActividades As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonMostrar As System.Windows.Forms.Button
    Friend WithEvents ObjetivosGeneralesToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ObjetivosEspecíficosToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActividadesToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
