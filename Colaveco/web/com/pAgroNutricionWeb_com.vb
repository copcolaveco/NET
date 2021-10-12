Public Class pAgroNutricionWeb_com
    Inherits Conectoras.ConexionMySQL_com
    Public Function guardar(ByVal o As Object) As Boolean
        Dim obj As dAgroNutricionWeb_com = CType(o, dAgroNutricionWeb_com)
        Dim sql As String = "INSERT INTO agro_nutricion (id, id_usuario, comentario, abonado, fecha_creado, fecha_emision, path_excel, path_pdf, path_csv, ficha, id_estado, id_libro) VALUES (" & obj.ID & "," & obj.ID_USUARIO & ",'" & obj.COMENTARIO & "'," & obj.ABONADO & ",'" & obj.FECHA_CREADO & "','" & obj.FECHA_EMISION & "','" & obj.PATH_EXCEL & "','" & obj.PATH_PDF & "','" & obj.PATH_CSV & "','" & obj.FICHA & "'," & obj.ID_ESTADO & "," & obj.ID_LIBRO & " )"

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object) As Boolean
        Dim obj As dAgroNutricionWeb_com = CType(o, dAgroNutricionWeb_com)
        Dim sql As String = "UPDATE agro_nutricion SET id_usuario = " & obj.ID_USUARIO & ",comentario='" & obj.COMENTARIO & "',abonado=" & obj.ABONADO & ",fecha_creado='" & obj.FECHA_CREADO & "',fecha_emision='" & obj.FECHA_EMISION & "',path_excel='" & obj.PATH_EXCEL & "',path_pdf='" & obj.PATH_PDF & "',path_csv='" & obj.PATH_CSV & "',ficha='" & obj.FICHA & "',id_estado=" & obj.ID_ESTADO & ",id_libro=" & obj.ID_LIBRO & "   WHERE ID = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar2(ByVal o As Object) As Boolean
        Dim obj As dAgroNutricionWeb_com = CType(o, dAgroNutricionWeb_com)
        Dim sql As String = "UPDATE agro_nutricion SET comentario='" & obj.COMENTARIO & "',abonado=" & obj.ABONADO & ",fecha_emision='" & obj.FECHA_EMISION & "',path_excel='" & obj.PATH_EXCEL & "',path_pdf='" & obj.PATH_PDF & "',path_csv='" & obj.PATH_CSV & "',id_estado=" & obj.ID_ESTADO & " WHERE ficha = " & obj.FICHA

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAgroNutricionWeb_com = CType(o, dAgroNutricionWeb_com)
        Dim sql As String = "DELETE FROM agro_nutricion WHERE ID = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminarxficha(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAgroNutricionWeb_com = CType(o, dAgroNutricionWeb_com)
        Dim sql As String = "DELETE FROM agro_nutricion WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dAgroNutricionWeb_com
        Dim obj As dAgroNutricionWeb_com = CType(o, dAgroNutricionWeb_com)
        Dim c As New dAgroNutricionWeb_com
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, id_usuario, ifnull(comentario,''), abonado, fecha_creado, fecha_emision, ifnull(path_excel,''), ifnull(path_pdf,''), ifnull(path_csv,''), ficha, id_estado, ifnull(id_libro,0) FROM agro_nutricion WHERE ficha = '" & obj.FICHA & "'")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.ID_USUARIO = CType(unaFila.Item(1), Long)
                c.COMENTARIO = CType(unaFila.Item(2), String)
                c.ABONADO = CType(unaFila.Item(3), Integer)
                c.FECHA_CREADO = CType(unaFila.Item(4), String)
                c.FECHA_EMISION = CType(unaFila.Item(5), String)
                c.PATH_EXCEL = CType(unaFila.Item(6), String)
                c.PATH_PDF = CType(unaFila.Item(7), String)
                c.PATH_CSV = CType(unaFila.Item(8), String)
                c.FICHA = CType(unaFila.Item(9), String)
                c.ID_ESTADO = CType(unaFila.Item(10), Integer)
                c.ID_LIBRO = CType(unaFila.Item(11), Long)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, id_usuario, comentario, abonado, fecha_creado, fecha_emision, path_excel, path_pdf, path_csv, ficha, id_estado, id_libro FROM agro_nutricion order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dAgroNutricionWeb_com
                    c.ID = CType(unaFila.Item(0), Long)
                    c.ID_USUARIO = CType(unaFila.Item(1), Long)
                    c.COMENTARIO = CType(unaFila.Item(2), String)
                    c.ABONADO = CType(unaFila.Item(3), Integer)
                    c.FECHA_CREADO = CType(unaFila.Item(4), String)
                    c.FECHA_EMISION = CType(unaFila.Item(5), String)
                    c.PATH_EXCEL = CType(unaFila.Item(6), String)
                    c.PATH_PDF = CType(unaFila.Item(7), String)
                    c.PATH_CSV = CType(unaFila.Item(8), String)
                    c.FICHA = CType(unaFila.Item(9), String)
                    c.ID_ESTADO = CType(unaFila.Item(10), Integer)
                    c.ID_LIBRO = CType(unaFila.Item(11), Long)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, id_usuario, comentario, abonado, fecha_creado, fecha_emision, path_excel, path_pdf, path_csv, ficha, id_estado, id_libro FROM agro_nutricion where ficha = " & texto)
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dAgroNutricionWeb_com
                    c.ID = CType(unaFila.Item(0), Long)
                    c.ID_USUARIO = CType(unaFila.Item(1), Long)
                    c.COMENTARIO = CType(unaFila.Item(2), String)
                    c.ABONADO = CType(unaFila.Item(3), Integer)
                    c.FECHA_CREADO = CType(unaFila.Item(4), String)
                    c.FECHA_EMISION = CType(unaFila.Item(5), String)
                    c.PATH_EXCEL = CType(unaFila.Item(6), String)
                    c.PATH_PDF = CType(unaFila.Item(7), String)
                    c.PATH_CSV = CType(unaFila.Item(8), String)
                    c.FICHA = CType(unaFila.Item(9), String)
                    c.ID_ESTADO = CType(unaFila.Item(10), Integer)
                    c.ID_LIBRO = CType(unaFila.Item(11), Long)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, id_usuario, comentario, abonado, fecha_creado, fecha_emision, path_excel, path_pdf, path_csv, ficha, id_estado, id_libro FROM agro_nutricion where ficha = " & texto & " Order by muestra asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dAgroNutricionWeb_com
                    c.ID = CType(unaFila.Item(0), Long)
                    c.ID_USUARIO = CType(unaFila.Item(1), Long)
                    c.COMENTARIO = CType(unaFila.Item(2), String)
                    c.ABONADO = CType(unaFila.Item(3), Integer)
                    c.FECHA_CREADO = CType(unaFila.Item(4), String)
                    c.FECHA_EMISION = CType(unaFila.Item(5), String)
                    c.PATH_EXCEL = CType(unaFila.Item(6), String)
                    c.PATH_PDF = CType(unaFila.Item(7), String)
                    c.PATH_CSV = CType(unaFila.Item(8), String)
                    c.FICHA = CType(unaFila.Item(9), String)
                    c.ID_ESTADO = CType(unaFila.Item(10), Integer)
                    c.ID_LIBRO = CType(unaFila.Item(11), Long)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, id_usuario, comentario, abonado, fecha_creado, fecha_emision, ifnull(path_excel,''), ifnull(path_pdf,''), ifnull(path_csv,''), ficha, id_estado, ifnull(id_libro,0) FROM agro_nutricion where fecha_emision BETWEEN '" & desde & "' AND '" & hasta & "' AND path_excel <>'' AND path_pdf <>''")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dAgroNutricionWeb_com
                    c.ID = CType(unaFila.Item(0), Long)
                    c.ID_USUARIO = CType(unaFila.Item(1), Long)
                    c.COMENTARIO = CType(unaFila.Item(2), String)
                    c.ABONADO = CType(unaFila.Item(3), Integer)
                    c.FECHA_CREADO = CType(unaFila.Item(4), String)
                    c.FECHA_EMISION = CType(unaFila.Item(5), String)
                    c.PATH_EXCEL = CType(unaFila.Item(6), String)
                    c.PATH_PDF = CType(unaFila.Item(7), String)
                    c.PATH_CSV = CType(unaFila.Item(8), String)
                    c.FICHA = CType(unaFila.Item(9), String)
                    c.ID_ESTADO = CType(unaFila.Item(10), Integer)
                    c.ID_LIBRO = CType(unaFila.Item(11), Long)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function modificarabonado(ByVal o As Object, ByVal ficha As Long, ByVal abonado As Integer) As Boolean
        Dim obj As dAgroNutricionWeb_com = CType(o, dAgroNutricionWeb_com)
        Dim sql As String = "UPDATE agro_nutricion SET abonado=" & abonado & " WHERE ficha = " & ficha & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
End Class
