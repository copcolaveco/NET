﻿Public Class pControlLecheroWeb_uy
    Inherits Conectoras.ConexionMySQL_uy
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dControlLecheroWeb_uy = CType(o, dControlLecheroWeb_uy)
        Dim sql As String = "INSERT INTO control_lechero (id, id_usuario, comentario, abonado, fecha_creado, fecha_emision, path_excel, path_pdf, path_csv, path_rodeo, ficha, id_estado, id_libro) VALUES (" & obj.ID & "," & obj.ID_USUARIO & ",'" & obj.COMENTARIO & "'," & obj.ABONADO & ",'" & obj.FECHA_CREADO & "','" & obj.FECHA_EMISION & "','" & obj.PATH_EXCEL & "','" & obj.PATH_PDF & "','" & obj.PATH_CSV & "','" & obj.PATH_RODEO & "','" & obj.FICHA & "'," & obj.ID_ESTADO & "," & obj.ID_LIBRO & " )"

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dControlLecheroWeb_uy = CType(o, dControlLecheroWeb_uy)
        Dim sql As String = "UPDATE control_lechero SET id_usuario = " & obj.ID_USUARIO & ",comentario='" & obj.COMENTARIO & "',abonado=" & obj.ABONADO & ",fecha_creado='" & obj.FECHA_CREADO & "',fecha_emision='" & obj.FECHA_EMISION & "',path_excel='" & obj.PATH_EXCEL & "',path_pdf='" & obj.PATH_PDF & "',path_csv='" & obj.PATH_CSV & "',path_rodeo='" & obj.PATH_RODEO & "',ficha='" & obj.FICHA & "',id_estado=" & obj.ID_ESTADO & ",id_libro=" & obj.ID_LIBRO & "   WHERE ID = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar2(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dControlLecheroWeb_uy = CType(o, dControlLecheroWeb_uy)
        Dim sql As String = "UPDATE control_lechero SET comentario='" & obj.COMENTARIO & "',abonado=" & obj.ABONADO & ",fecha_emision='" & obj.FECHA_EMISION & "',path_excel='" & obj.PATH_EXCEL & "',path_pdf='" & obj.PATH_PDF & "',path_csv='" & obj.PATH_CSV & "',path_rodeo='" & obj.PATH_RODEO & "',id_estado=" & obj.ID_ESTADO & " WHERE ficha = " & obj.FICHA

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dControlLecheroWeb_uy = CType(o, dControlLecheroWeb_uy)
        Dim sql As String = "DELETE FROM control_lechero WHERE ID = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dControlLecheroWeb_uy
        Dim obj As dControlLecheroWeb_uy = CType(o, dControlLecheroWeb_uy)
        Dim c As New dControlLecheroWeb_uy
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, id_usuario, ifnull(comentario,''), abonado, fecha_creado, fecha_emision, ifnull(path_excel,''), ifnull(path_pdf,''), ifnull(path_csv,''),ifnull(path_rodeo,''), ficha, id_estado, ifnull(id_libro,0) FROM control_lechero WHERE ficha = '" & obj.FICHA & "'")

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
                c.PATH_RODEO = CType(unaFila.Item(9), String)
                c.FICHA = CType(unaFila.Item(10), String)
                c.ID_ESTADO = CType(unaFila.Item(11), Integer)
                c.ID_LIBRO = CType(unaFila.Item(12), Long)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, id_usuario, comentario, abonado, fecha_creado, fecha_emision, path_excel, path_pdf, path_csv, path_rodeo,ficha, id_estado, id_libro FROM control_lechero order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dControlLecheroWeb_uy
                    c.ID = CType(unaFila.Item(0), Long)
                    c.ID_USUARIO = CType(unaFila.Item(1), Long)
                    c.COMENTARIO = CType(unaFila.Item(2), String)
                    c.ABONADO = CType(unaFila.Item(3), Integer)
                    c.FECHA_CREADO = CType(unaFila.Item(4), String)
                    c.FECHA_EMISION = CType(unaFila.Item(5), String)
                    c.PATH_EXCEL = CType(unaFila.Item(6), String)
                    c.PATH_PDF = CType(unaFila.Item(7), String)
                    c.PATH_CSV = CType(unaFila.Item(8), String)
                    c.PATH_RODEO = CType(unaFila.Item(9), String)
                    c.FICHA = CType(unaFila.Item(10), String)
                    c.ID_ESTADO = CType(unaFila.Item(11), Integer)
                    c.ID_LIBRO = CType(unaFila.Item(12), Long)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, id_usuario, comentario, abonado, fecha_creado, fecha_emision, path_excel, path_pdf, path_csv,path_rodeo, ficha, id_estado, id_libro FROM control_lechero where ficha = " & texto)
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dControlLecheroWeb_uy
                    c.ID = CType(unaFila.Item(0), Long)
                    c.ID_USUARIO = CType(unaFila.Item(1), Long)
                    c.COMENTARIO = CType(unaFila.Item(2), String)
                    c.ABONADO = CType(unaFila.Item(3), Integer)
                    c.FECHA_CREADO = CType(unaFila.Item(4), String)
                    c.FECHA_EMISION = CType(unaFila.Item(5), String)
                    c.PATH_EXCEL = CType(unaFila.Item(6), String)
                    c.PATH_PDF = CType(unaFila.Item(7), String)
                    c.PATH_CSV = CType(unaFila.Item(8), String)
                    c.PATH_RODEO = CType(unaFila.Item(9), String)
                    c.FICHA = CType(unaFila.Item(10), String)
                    c.ID_ESTADO = CType(unaFila.Item(11), Integer)
                    c.ID_LIBRO = CType(unaFila.Item(12), Long)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, id_usuario, comentario, abonado, fecha_creado, fecha_emision, path_excel, path_pdf, path_csv, path_rodeo, ficha, id_estado, id_libro FROM control_lechero where ficha = " & texto & " Order by muestra asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dControlLecheroWeb_uy
                    c.ID = CType(unaFila.Item(0), Long)
                    c.ID_USUARIO = CType(unaFila.Item(1), Long)
                    c.COMENTARIO = CType(unaFila.Item(2), String)
                    c.ABONADO = CType(unaFila.Item(3), Integer)
                    c.FECHA_CREADO = CType(unaFila.Item(4), String)
                    c.FECHA_EMISION = CType(unaFila.Item(5), String)
                    c.PATH_EXCEL = CType(unaFila.Item(6), String)
                    c.PATH_PDF = CType(unaFila.Item(7), String)
                    c.PATH_CSV = CType(unaFila.Item(8), String)
                    c.PATH_RODEO = CType(unaFila.Item(9), String)
                    c.FICHA = CType(unaFila.Item(10), String)
                    c.ID_ESTADO = CType(unaFila.Item(11), Integer)
                    c.ID_LIBRO = CType(unaFila.Item(12), Long)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
