Public Class pClientesG2000
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dClientesG2000 = CType(o, dClientesG2000)
        Dim sql As String = "INSERT INTO clientesg2000 (codigo, nombre, rsocial, rut, direccion, localidad, departamento, cpostal, giro, telefonos, fax, email, contacto, observaciones) VALUES ('" & obj.CODIGO & "', '" & obj.NOMBRE & "', '" & obj.RSOCIAL & "', '" & obj.RUT & "', '" & obj.DIRECCION & "', '" & obj.LOCALIDAD & "', " & obj.DEPARTAMENTO & ", '" & obj.CPOSTAL & "', " & obj.GIRO & ", '" & obj.TELEFONOS & "', '" & obj.FAX & "', '" & obj.EMAIL & "', '" & obj.CONTACTO & "', '" & obj.OBSERVACIONES & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'clientesg2000', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dClientesG2000 = CType(o, dClientesG2000)
        Dim sql As String = "UPDATE clientesg2000 SET nombre='" & obj.NOMBRE & "', rsocial='" & obj.RSOCIAL & "', rut='" & obj.RUT & "',  direccion='" & obj.DIRECCION & "', localidad='" & obj.LOCALIDAD & "', departamento=" & obj.DEPARTAMENTO & ", cpostal='" & obj.CPOSTAL & "', giro=" & obj.GIRO & ", telefonos='" & obj.TELEFONOS & "', fax='" & obj.FAX & "', email='" & obj.EMAIL & "', contacto='" & obj.CONTACTO & "', observaciones='" & obj.OBSERVACIONES & "' WHERE codigo = '" & obj.CODIGO & "'"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'clientesg2000', 'modificación', '" & obj.CODIGO & "', " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dClientesG2000 = CType(o, dClientesG2000)
        Dim sql As String = "DELETE FROM clientesg2000 WHERE codigo = '" & obj.CODIGO & "'"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'clientesg2000', 'eliminación', '" & obj.CODIGO & "', " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dClientesG2000
        Dim obj As dClientesG2000 = CType(o, dClientesG2000)
        Dim p As New dClientesG2000
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT ifnull(nombre,''), ifnull(rsocial,''), ifnull(rut,''), ifnull(direccion,''), ifnull(localidad,''), ifnull(departamento,0), ifnull(cpostal,''), ifnull(giro,0), ifnull(telefonos,''), ifnull(fax,''), ifnull(email,''), ifnull(contacto,''), ifnull(observaciones,'') FROM clientesg2000 WHERE codigo = '" & obj.CODIGO & "'")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.CODIGO = CType(unaFila.Item(0), String)
                p.NOMBRE = CType(unaFila.Item(1), String)
                p.RSOCIAL = CType(unaFila.Item(2), String)
                p.RUT = CType(unaFila.Item(3), String)
                p.DIRECCION = CType(unaFila.Item(4), String)
                p.LOCALIDAD = CType(unaFila.Item(5), String)
                p.DEPARTAMENTO = CType(unaFila.Item(6), Integer)
                p.CPOSTAL = CType(unaFila.Item(7), String)
                p.GIRO = CType(unaFila.Item(8), Integer)
                p.TELEFONOS = CType(unaFila.Item(9), String)
                p.FAX = CType(unaFila.Item(10), String)
                p.EMAIL = CType(unaFila.Item(11), String)
                p.CONTACTO = CType(unaFila.Item(12), String)
                p.OBSERVACIONES = CType(unaFila.Item(13), String)
                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
   
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT ifnull(codigo,''), ifnull(nombre,''), ifnull(rsocial,''), ifnull(rut,''), ifnull(direccion,''), ifnull(localidad,''), ifnull(departamento,0), ifnull(cpostal,''), ifnull(giro,0), ifnull(telefonos,''), ifnull(fax,''), ifnull(email,''), ifnull(contacto,''), ifnull(observaciones,'') FROM clientesg2000 order by Nombre asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dClientesG2000
                    p.CODIGO = CType(unaFila.Item(0), String)
                    p.NOMBRE = CType(unaFila.Item(1), String)
                    p.RSOCIAL = CType(unaFila.Item(2), String)
                    p.RUT = CType(unaFila.Item(3), String)
                    p.DIRECCION = CType(unaFila.Item(4), String)
                    p.LOCALIDAD = CType(unaFila.Item(5), String)
                    p.DEPARTAMENTO = CType(unaFila.Item(6), Integer)
                    p.CPOSTAL = CType(unaFila.Item(7), String)
                    p.GIRO = CType(unaFila.Item(8), Integer)
                    p.TELEFONOS = CType(unaFila.Item(9), String)
                    p.FAX = CType(unaFila.Item(10), String)
                    p.EMAIL = CType(unaFila.Item(11), String)
                    p.CONTACTO = CType(unaFila.Item(12), String)
                    p.OBSERVACIONES = CType(unaFila.Item(13), String)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
   
 
    
End Class
